using AutoMapper;
using Ecom.DataAccess.DBConfig;
using Ecom.DataAccess.DBCredentials;
using Ecom.SharedLibrary.Common;

using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELC.DataAccess.DBCredentials
{
    public class ApplicationCredentials : IApplicationCredentials
    {
        private readonly AppSettings _appSettings;
        private readonly IClientDBConnection _dbConnection;

        public ApplicationCredentials(IOptions<AppSettings> appSettings, IClientDBConnection dbConnection,
                                        IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _dbConnection = dbConnection;
        }

        public async Task SetAppDomain()
        {
            _dbConnection.SetEfDBString(GetEfConnection());
        }

        public string GetEfConnection()
        {
            return _appSettings.EcomConnectionString;
        }
    }
}