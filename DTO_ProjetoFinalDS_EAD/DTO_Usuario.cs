using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ProjetoFinalDS_EAD
{
    public class DTO_Usuario
    {
        public int idUsuario { get; set; }
        public string Nome { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfSenha { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Tipo { get; set; }
        public string DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Ativo { get; set; }
        public string TelFixo { get; set; }
        public string TelCelular { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public bool StatusLogin { get; set; }
        public string AcaoUsuario { get; set; }
    }
}
