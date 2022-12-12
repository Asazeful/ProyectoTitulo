using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class VentasBLL
    {
        NegocioPlayEntities db = new NegocioPlayEntities();
        ///Crud de las ventas
        
        //Añadir una nueva venta
        public void Add(DateTime fecha_venta, int total_venta, int? cod_cliente = null )
            {
                Ventas venta = new Ventas();
                venta.fecha_venta = fecha_venta;
                venta.total = total_venta;
                venta.cod_cliente = cod_cliente;

                db.Ventas.Add(venta);
                db.SaveChanges();
            }
        //Listar ventas con y sin filtro
        public List<Ventas> GetVentas()
            {
                return db.Ventas.ToList();
            }
        public List<Ventas> GetPorFecha(DateTime fecha)
            {
                return db.Ventas.Where(v => v.fecha_venta == fecha & v.total >0).ToList();
            }
        public List<Ventas> GetPorCliente(int cliente)
            {
            return db.Ventas.Where(v => v.cod_cliente == cliente).ToList();
            }
        public List<Ventas> GetPorImporte()
            {
            return db.Ventas.Where(v => v.total >0).ToList();
        }
        //Actualizar total
        public void ActualizarTotal(Ventas venta, int total)
            {
            Ventas v = this.Get(venta.cod_venta);

            v.total = total;

            db.SaveChanges();
        }

        //get
        public Ventas Get(int id)
            {
                Ventas venta = db.Ventas.Where(v => v.cod_venta == id).FirstOrDefault();
                return venta;
            }

        //Get ultima venta
        public int GetUltima()
        {
            int cod_ventas = db.Ventas.Max(c=>c.cod_venta);
            return cod_ventas;
        }
        //Delete
        public void Delete(int cod_venta)
        {
            Ventas venta = this.Get(cod_venta);

            db.Ventas.Remove(venta);
            db.SaveChanges();
        }
        //Actualizar deudor
        public void ActualizarDeudor(int cod_cliente, int cod_venta)
        {
            Ventas venta = this.Get(cod_venta);

            venta.cod_cliente = cod_cliente;
            db.SaveChanges();
        }
    }
}
