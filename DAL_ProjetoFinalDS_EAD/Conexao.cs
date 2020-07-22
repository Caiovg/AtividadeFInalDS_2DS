using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL_ProjetoFinalDS_EAD
{
    class Conexao
    {
        public static SqlConnection Conectar()
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetoFinalDS_EAD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //pegar o caminho na propriedade do banco
                //Esta em connection string o @ no começo e prioridade
                conn.Open();
                return conn;
            }
            catch
            {
                throw new Exception("Não foi possivel conectar com o servidor");
            }
        }
    }
}
