using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
   public class User
    {
        public enum TipoUser
        {
            NORMAL = 0,
            ADMIN = 1
        }

        public int Id { get; set; }

        public string Usuario { get; set; }

        public string Pass { get; set; }

        public TipoUser TipoUsuario { get; set; }


    }
}
