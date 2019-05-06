using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda_Entidades;
using Tienda_AccesoDatos;

namespace Tienda_LogicaNegocio
{
    public class TiposClientesBOL
    {
        private TiposClientesDAL _TiposClientes = new TiposClientesDAL();
       
        public  List<ETiposClientes> Todos()
        {
            return _TiposClientes.GetAll();
        }
    }
}
