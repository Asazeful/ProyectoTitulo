using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class DetalleCompraBLL
    {
        NegocioPlayEntities db = new NegocioPlayEntities();

        //Añadir
        public void Add(int cod_compra, int cantidad, int cod_producto, int precio_producto)
        {
            Detalle_compra detalle = new Detalle_compra();

            detalle.cod_compra = cod_compra;
            detalle.cantidad = cantidad;
            detalle.cod_producto = cod_producto;
            detalle.subtotal = precio_producto * cantidad;

            db.Detalle_compra.Add(detalle);
            db.SaveChanges();
        }

        //Listar
        public List<Detalle_compra> GetDetalles(int cod_compra)
        {
            return db.Detalle_compra.Where(d => d.cod_compra == cod_compra).ToList();
        }

        //Obtener total
        public int GetTotal(int cod_compra)
        {
            int total = 0;
            for (int i = 0; i < db.Detalle_compra.Where(c=>c.cod_compra == cod_compra).Count();)
            {
                List<Detalle_compra> subtotales = db.Detalle_compra.Where(d => d.cod_compra == cod_compra).ToList();
                total = Convert.ToInt32(subtotales[i].subtotal) + total;
                i++;
            }
            return total;

        }

        //Delete masivo
        public void Delete(int cod_compra)
        {
            List < Detalle_compra > detalle = db.Detalle_compra.Where(d => d.cod_compra == cod_compra).ToList();
            db.Detalle_compra.RemoveRange(detalle);
            db.SaveChanges();
        }
        //DeleteUno
        public void DeleteUno(int cod_detalle)
        {
            Detalle_compra detalle = db.Detalle_compra.Where(d => d.cod_detalle == cod_detalle).FirstOrDefault();
            db.Detalle_compra.Remove(detalle);
            db.SaveChanges();
        }
    }
}
