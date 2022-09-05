using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estanteria.Clases
{
    internal class Estante
    {
        private int _ubicacion;
        private Producto[] _productos;

        private Estante(int capacidad)
        {
            _productos = new Producto[capacidad];
        }

        public Estante(int capacidad, int ubicacion): this(capacidad)
        {
            _ubicacion = ubicacion;
        }

        public Producto[] GetProductos()
        {
            return _productos;
        }

        public static string MostrarEstante(Estante estante)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Ubicacion:{estante._ubicacion}");
            sb.AppendLine("Productos: ");
            foreach (var prod in estante.GetProductos())
            {
                sb.AppendLine($"{Producto.MostrarProducto(prod)}");
            }
            return sb.ToString();
        }

        public static bool operator ==(Estante estante, Producto producto)
        {
            bool rtn = false;

            foreach (var prod in estante.GetProductos())
            {
                if(producto == prod)
                {
                    rtn = true;
                }
            }
            return rtn;
        }

        public static bool operator !=(Estante estante, Producto producto)
        {
            return !(estante == producto);
        }

        public static bool operator +(Estante e, Producto p)
        {
            bool rtn = false;

            for(int i = 0; i < e.GetProductos().Length; i++)
            {
                if (e._productos[i] is null)
                {
                    if (e == p)
                    {
                        e._productos[i] = p;
                        rtn = true;
                    }
                }
            }

            return rtn;
        }

        public static bool operator -(Estante e, Producto p)
        {
            for (int i = 0; i < e.GetProductos().Length; i++)
            {
                if (e._productos[i] is not null)
                {
                    if (e == p)
                    {
                        e._productos[i] = null;
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
