using Ecom.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.DBContext.Interface
{
    public interface IEcomDbContext
    {
        EcomDBContext Instance { get; }
        DbSet<Address> Addresses { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<OrderItem> OrderItems { get; set; }

        DbSet<Payment> Payments { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Review> Reviews { get; set; }

        DbSet<User> Users { get; set; }
    }
}
