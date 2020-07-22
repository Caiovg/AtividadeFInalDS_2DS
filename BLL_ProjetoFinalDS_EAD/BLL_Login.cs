using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_ProjetoFinalDS_EAD;
using DTO_ProjetoFinalDS_EAD;

namespace BLL_ProjetoFinalDS_EAD
{
    public class BLL_Login
    {
        public static DTO_Usuario ValidarLogin(DTO_Login obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Usuario))
            {
                throw new Exception("Campo Úsuario vazio!");
            }
            if (string.IsNullOrWhiteSpace(obj.Senha))
            {
                throw new Exception("Campo Senha vazio!");
            }
            return DAL_Login.vldLogin(obj);
        }
    }
}
