using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_ProjetoFinalDS_EAD;
using System.Data;
using System.Data.SqlClient;

namespace DAL_ProjetoFinalDS_EAD
{
    public class DAL_Cadastro
    {
        public static string CadFuncionario(DTO_Usuario obj)
        {
            try
            {
                string script = "INSERT INTO Usuarios (nome, email, userName, senha, tipo, dtNascimento, sexo, telFixo, telCelular, endereco, numero, bairro, cidade, estado, cep, ativo, RG, CPF) " +
                                "VALUES (@nome, @email, @userName, @senha, @tipo, @dtNascimento, @sexo, @telFixo, @telCelular, @endereco, @numero, @bairro, @cidade, @estado, @cep, @ativo, @RG, @CPF)";
                SqlCommand cm = new SqlCommand(script, Conexao.Conectar());

                cm.Parameters.AddWithValue("@nome", obj.Nome);
                cm.Parameters.AddWithValue("@email", obj.Email);
                cm.Parameters.AddWithValue("@userName", obj.UserName);
                cm.Parameters.AddWithValue("@senha", obj.Senha);
                cm.Parameters.AddWithValue("@tipo", obj.Tipo);
                cm.Parameters.AddWithValue("@dtNascimento", obj.DataNascimento);
                cm.Parameters.AddWithValue("@sexo", obj.Sexo);
                cm.Parameters.AddWithValue("@telFixo", obj.TelFixo);
                cm.Parameters.AddWithValue("@telCelular", obj.TelCelular);
                cm.Parameters.AddWithValue("@endereco", obj.Endereco);
                cm.Parameters.AddWithValue("@numero", obj.Numero);
                cm.Parameters.AddWithValue("@bairro", obj.Bairro);
                cm.Parameters.AddWithValue("@cidade", obj.Cidade);
                cm.Parameters.AddWithValue("@estado", obj.Estado);
                cm.Parameters.AddWithValue("@cep", obj.CEP);
                cm.Parameters.AddWithValue("@ativo", obj.Ativo);
                cm.Parameters.AddWithValue("@RG", obj.RG);
                cm.Parameters.AddWithValue("@CPF", obj.CPF);

                cm.ExecuteNonQuery();

                return ("Cadastrado efetuado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conexao.Conectar().State != ConnectionState.Closed)
                {
                    Conexao.Conectar().Close();
                }
            }
        }

        public static DTO_Usuario BuscarUsuario(string cpf)
        {
            try
            {
                string script = "SELECT * FROM Usuarios WHERE CPF = @CPF AND tipo != 'cliente' AND ativo = 'Ativo'";
                SqlCommand cm = new SqlCommand(script, Conexao.Conectar());
                //sempre nessa ordem, chamando o metodo de conectar
                cm.Parameters.AddWithValue("@CPF", cpf);
                //substitui as variaveis na instruçao sql pelos valores digitados pelo usuario

                SqlDataReader dados = cm.ExecuteReader();
                //roda a intruçao sql e atribui resultado no SqlDataReader

                while (dados.Read())
                //le a proxima linha do resultado da sua instruçao
                {
                    if (dados.HasRows)
                    //se der certo vai aparecer a message de conexao feita
                    {
                        DTO_Usuario usuario = new DTO_Usuario();
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

                        return usuario;
                    }

                }
                throw new Exception("Usuario não encontrado. Verifique o código!");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de conexão, contate o suporte! " + ex.Message);
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

        public static string AlterarFuncionario(DTO_Usuario obj)
        {
            try
            {
                string script = "UPDATE Usuarios SET nome = @nome, " +
                    "email = @email, userName = @userName, senha = @senha, " +
                    "tipo = @tipo, dtNascimento = @dtNascimento, sexo = @sexo, " +
                    "telFixo = @telFixo, telCelular = @telCelular, endereco = @endereco, " +
                    "numero = @numero, bairro = @bairro, cidade = @cidade, " +
                    "estado = @estado, cep = @cep, ativo = @ativo, RG = @RG, " +
                    "CPF = @CPF WHERE idUsuario = @idUsuario";
                SqlCommand cm = new SqlCommand(script, Conexao.Conectar());
                cm.Parameters.AddWithValue("@idUsuario", obj.idUsuario);
                cm.Parameters.AddWithValue("@nome", obj.Nome);
                cm.Parameters.AddWithValue("@email", obj.Email);
                cm.Parameters.AddWithValue("@userName", obj.UserName);
                cm.Parameters.AddWithValue("@senha", obj.Senha);
                cm.Parameters.AddWithValue("@tipo", obj.Tipo);
                cm.Parameters.AddWithValue("@dtNascimento", obj.DataNascimento);
                cm.Parameters.AddWithValue("@sexo", obj.Sexo);
                cm.Parameters.AddWithValue("@telFixo", obj.TelFixo);
                cm.Parameters.AddWithValue("@telCelular", obj.TelCelular);
                cm.Parameters.AddWithValue("@endereco", obj.Endereco);
                cm.Parameters.AddWithValue("@numero", obj.Numero);
                cm.Parameters.AddWithValue("@bairro", obj.Bairro);
                cm.Parameters.AddWithValue("@cidade", obj.Cidade);
                cm.Parameters.AddWithValue("@estado", obj.Estado);
                cm.Parameters.AddWithValue("@cep", obj.CEP);
                cm.Parameters.AddWithValue("@ativo", obj.Ativo);
                cm.Parameters.AddWithValue("@RG", obj.RG);
                cm.Parameters.AddWithValue("@CPF", obj.CPF);

                cm.ExecuteNonQuery();

                return "Usuario alterado com sucesso!";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conexao.Conectar().State != ConnectionState.Closed)
                {
                    Conexao.Conectar().Close();
                }
            }
        }
    }
}
