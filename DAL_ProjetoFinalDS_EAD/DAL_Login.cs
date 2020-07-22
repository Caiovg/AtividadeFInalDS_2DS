using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO_ProjetoFinalDS_EAD;

namespace DAL_ProjetoFinalDS_EAD
{
    public class DAL_Login
    {
        public static DTO_Usuario vldLogin(DTO_Login obj)
        {
            try
            {
                string script = "SELECT * FROM Usuarios WHERE(userName = @login OR email = @login)" +
                    "AND senha = @senha";
                SqlCommand cm = new SqlCommand(script, Conexao.Conectar());
                //sempre nessa ordem, chamando o metodo de conectar
                cm.Parameters.AddWithValue("@login", obj.Usuario);
                cm.Parameters.AddWithValue("@senha", obj.Senha);
                //substitui as variaveis na instruçao sql pelos valores digitados pelo usuario


                SqlDataReader dados = cm.ExecuteReader();
                //roda a intruçao sql e atribui resultado no SqlDataReader
                DTO_Usuario usuario = new DTO_Usuario();

                while (dados.Read())
                //le a proxima linha do resultado da sua instruçao
                {
                    if (dados.HasRows)
                    //se der certo vai aparecer a message de conexao feita
                    {
                        
                        usuario.idUsuario = int.Parse(dados["idUsuario"].ToString());
                        usuario.Nome = dados["nome"].ToString();
                        usuario.Email = dados["email"].ToString();
                        usuario.UserName = dados["userName"].ToString();
                        usuario.Senha = dados["senha"].ToString();
                        usuario.Tipo = dados["tipo"].ToString();
                        usuario.DataNascimento = dados["dtNascimento"].ToString();
                        usuario.Sexo = dados["sexo"].ToString();
                        usuario.TelFixo = dados["telFixo"].ToString();
                        usuario.TelCelular = dados["telCelular"].ToString();
                        usuario.Endereco = dados["endereco"].ToString();
                        usuario.Numero = dados["numero"].ToString();
                        usuario.Bairro = dados["bairro"].ToString();
                        usuario.Cidade = dados["cidade"].ToString();
                        usuario.Estado = dados["estado"].ToString();
                        usuario.CEP = dados["cep"].ToString();
                        usuario.Ativo = dados["ativo"].ToString();
                        usuario.RG = dados["RG"].ToString();
                        usuario.CPF = dados["CPF"].ToString();
                        usuario.StatusLogin = true;
                        return usuario;
                    }

                }
                usuario.StatusLogin = false;
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally //finally acontece independente se acontece o try ou catch
            {
                if (Conexao.Conectar().State != ConnectionState.Closed)
                //testando o estado da conexao, se é diferente de fechado
                {
                    Conexao.Conectar().Close();
                }
            }
        }
    }
}
