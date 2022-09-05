using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estanteria.Clases
{
    internal class Producto
    {
        private string _codigoDeBarra = "";
        private string _marca;
        private float _precio;

        public Producto(string marca, string codigoDeBarra, float precio)
        {
            _codigoDeBarra = codigoDeBarra;
            _marca = marca;
            _precio = precio;
        }


        public string GetMarca()
        {
            return _marca;
        }
        public float GetPrecio()
        {
            return _precio;
        }

        public static string MostrarProducto(Producto prod)
        {
            StringBuilder sb = new StringBuilder();
            if (prod is not null)
            {
                sb.Append("Marca:");
                sb.AppendLine(prod._marca);
                sb.Append("Precio:");
                sb.AppendLine(prod._precio.ToString());
                sb.Append("Codigo de barras:");
                sb.AppendLine((string)prod);

            }
        
            return sb.ToString();

        }


        public static explicit operator string(Producto prod)
        {
            if(prod is not null)
            {
                return prod._codigoDeBarra;
            }
            return "";
        }
        
        public static bool operator == (Producto p1, Producto p2)
        {
            return (string)p1 == (string)p2 && p1.GetMarca() == p2.GetMarca();
        }

        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }

        public static bool operator ==(Producto p1, string str)
        {
            return p1.GetMarca() == str;
        }
        public static bool operator !=(Producto p1, string str)
        {
            return !(p1.GetMarca() == str);
        }
    }

}
