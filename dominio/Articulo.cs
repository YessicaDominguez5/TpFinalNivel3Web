using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }

        public string CodigoArticulo { get; set; }

        public string NombreArticulo { get; set; }

        public string DescripcionArticulo { get; set; }


        public Marca MarcaArticulo { get; set; }

        public Categoria CategoriaArticulo { get; set; }

        public string UrlImagenArticulo { get; set; }


        public decimal PrecioArticulo { get; set; }

      

    }
}
