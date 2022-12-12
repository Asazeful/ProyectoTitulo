using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public 
        class DetalleVentaBLL
    {
        NegocioPlayEntities db = new NegocioPlayEntities();
        

        //Esta es la parte complicada, pero, se que tu puedes uwu
        ////Crud
        
        //Nuevo detalle
        public void Add(int cod_venta, int cod_producto, int cantidad, int precio_producto)
        {
            Detalle_ventas detalle = new Detalle_ventas();

            detalle.cod_ventas = cod_venta;
            detalle.cod_producto = cod_producto;
            detalle.cantidad = cantidad;
            detalle.precio_producto = precio_producto;
            detalle.subtotal = precio_producto * cantidad;

            db.Detalle_ventas.Add(detalle);
            db.SaveChanges();
        }
        //Listar
        public List<Detalle_ventas> GetDetalle_Ventas(int cod_venta)
        {
            return db.Detalle_ventas.Where(d => d.cod_ventas == cod_venta).ToList();
        }
        //Obtener total
        public int GetTotal(int cod_venta)
        {
            int total = 0;
            for(int i=0;i < db.Detalle_ventas.Where(v=>v.cod_ventas == cod_venta).Count();)
            {
                List<Detalle_ventas> subtotales = db.Detalle_ventas.Where(d=>d.cod_ventas == cod_venta).ToList();
                total = Convert.ToInt32(subtotales[i].subtotal) + total;
                i++;
            }
            return total;
        }

        //Eliminar
        public void Delete(int cod_venta)
        {
            List<Detalle_ventas> detalle = db.Detalle_ventas.Where(d => d.cod_ventas == cod_venta).ToList();
            db.Detalle_ventas.RemoveRange(detalle);
            db.SaveChanges();
        }
        public void DeleteUno (int cod_detalle)
        {
            Detalle_ventas detalle = this.Get(cod_detalle);
            db.Detalle_ventas.Remove(detalle);
            db.SaveChanges();
        }

        //get

        public Detalle_ventas Get(int cod_detalle)
        {
            Detalle_ventas detalle = db.Detalle_ventas.Where(d=>d.cod_detalle == cod_detalle).FirstOrDefault();
            return detalle;
        }
    }
}
