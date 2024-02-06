using Ecom.DataAccess.DBConfig;
using Ecom.DataAccess.DBContext.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.DBContext
{
   public partial class EcomDBContext:IEcomDbContext
    {
        private readonly IClientDBConnection _clientDBConnection;

        public EcomDBContext(IClientDBConnection clientDBConnection)
        {
            this._clientDBConnection = clientDBConnection;
        }

        public EcomDBContext(DbContextOptions<EcomDBContext> options):base(options) { }

        public EcomDBContext Instance => this;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
                //       => optionsBuilder.UseSqlServer("Server=LAPTOP-MIB0F8M3;Initial Catalog=Ecom;User Id=sa;Password=12345;TrustServerCertificate=True;");

                optionsBuilder.UseSqlServer(this._clientDBConnection.getEfDBString(), options =>
                {
                    options.CommandTimeout(35);
                    options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);
                });
            }
        }


    }
}
