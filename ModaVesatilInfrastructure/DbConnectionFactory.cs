using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVesatilInfrastructure
{
    public class DbConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ObterStringDeConexao()
        {
            var servidor = "Ricardo";
            var usuario = "sa";
            var senha = "1Q2w3e4r";

            string? connectionString = _configuration.GetConnectionString("DefaultConnection");

            connectionString = connectionString.Replace("[SERVIDOR_BANCO]", servidor).Replace("[USUARIO_BANCO]", usuario).Replace("[SENHA_BANCO]", senha);

            return connectionString;
        }
    }
}
