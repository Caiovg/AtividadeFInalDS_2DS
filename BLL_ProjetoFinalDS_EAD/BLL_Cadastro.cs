using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_ProjetoFinalDS_EAD;
using DTO_ProjetoFinalDS_EAD;

namespace BLL_ProjetoFinalDS_EAD
{
    public class BLL_Cadastro
    {
        public static string CadUsuario(DTO_Usuario obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Nome))
            {
                throw new Exception("Campo Nome Vazio!");
            }
            if (string.IsNullOrWhiteSpace(obj.UserName))
            {
                throw new Exception("Campo UserName Vazio!");
            }
            if (string.IsNullOrWhiteSpace(obj.Email))
            {
                throw new Exception("Campo Email Vazio!");
            }
            if (string.IsNullOrWhiteSpace(obj.CPF))
            {
                throw new Exception("Campo CPF Vazio");
            }
            if (obj.CPF.Length != 11)
            {
                throw new Exception("Campo CPF precisa conter 11 caracteres!");
            }
            try
            {
                Int64.Parse(obj.CPF);
            }
            catch
            {
                throw new Exception("CPF deve ser numérico!");
            }
            if (string.IsNullOrWhiteSpace(obj.RG))
            {
                throw new Exception("Digite o numero dp RG!");
            }
            if (string.IsNullOrWhiteSpace(obj.DataNascimento))
            {
                throw new Exception("Digite a sua Data de Nascimento!");
            }
            if (obj.TelFixo != "")
            {
                if (obj.TelFixo.Length < 10)
                {
                    throw new Exception("Numero de telefone fixo inválido!");
                }
            }
            if (string.IsNullOrWhiteSpace(obj.TelCelular))
            {
                throw new Exception("Preencha o número do seu telefone celular!");
            }
            if (obj.TelCelular.Length < 11)
            {
                throw new Exception("Numero de telefone celular inválido!");
            }
            if (string.IsNullOrWhiteSpace(obj.Tipo))
            {
                throw new Exception("Selecione o cargo do funcionário!");
            }
            if (string.IsNullOrWhiteSpace(obj.Endereco))
            {
                throw new Exception("Digite seu endereço!");
            }
            if (string.IsNullOrWhiteSpace(obj.Numero))
            {
                throw new Exception("Digite o número do imóvel!");
            }
            if (string.IsNullOrWhiteSpace(obj.Bairro))
            {
                throw new Exception("Digite o bairro!");
            }
            if (string.IsNullOrWhiteSpace(obj.Cidade))
            {
                throw new Exception("Digite a cidade!");
            }
            if (string.IsNullOrWhiteSpace(obj.Estado))
            {
                throw new Exception("Selecione o estado!");
            }
            if (string.IsNullOrWhiteSpace(obj.CEP))
            {
                throw new Exception("Preencha o número do CEP!");
            }
            if (obj.CEP.Length < 8)
            {
                throw new Exception("Numero de CEP inválido!");
            }
            if (string.IsNullOrWhiteSpace(obj.Sexo))
            {
                throw new Exception("Selecione o sexo do funcionário!");
            }
            if (string.IsNullOrWhiteSpace(obj.Ativo))
            {
                throw new Exception("Selecione entre ativo ou inativo!");
            }
            if (string.IsNullOrWhiteSpace(obj.Senha))
            {
                throw new Exception("Campo Senha Vazio!");
            }
            if (string.IsNullOrWhiteSpace(obj.ConfSenha))
            {
                throw new Exception("Campo Confirme sua senha");
            }
            if (obj.Senha == obj.ConfSenha)
            {

            }
            else
            {
                throw new Exception("senha diferente");
            }
            switch (obj.AcaoUsuario)
            {
                case "cadastro":
                    return DAL_Cadastro.CadFuncionario(obj);
                //break;
                case "alteracao":
                    return DAL_Cadastro.AlterarFuncionario(obj);
                default:
                    throw new Exception("algo errado aconteceu!");
            }
        }

        public static DTO_Usuario BuscarUsuario(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                throw new Exception("Campo CPF Vazio");
            }
            try
            {
                Convert.ToInt64(cpf);
            }
            catch
            {
                throw new Exception("CPF deve ser numérico!");
            }
            if (cpf.Length != 11)
            {
                throw new Exception("CPF deve ter 13 digitos!");
            }
            return DAL_Cadastro.BuscarUsuario(cpf);
        }
    }
}
