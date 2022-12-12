using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CompraBLL
    {
        NegocioPlayEntities db = new NegocioPlayEntities();

        //Añadir compra
        public void Add(DateTime fecha_compra, int total, int? cod_proveedor = null)
        {
            Compras nueva = new Compras();
            nueva.total = total;
            nueva.fecha_compra = fecha_compra;
            nueva.cod_proveedor = cod_proveedor;

            db.Compras.Add(nueva);
            db.SaveChanges();
        }

        //Listar compras

        public List<Compras> GetCompras()
        {
            return db.Compras.Where(c=>c.total > 0).ToList();
        }

        public List<Compras> GetPorFecha(DateTime fecha)
        {
            return db.Compras.Where(c => c.fecha_compra == fecha).ToList();
        }

        public List<Compras>GetPorTotal(int total)
        {
            return db.Compras.Where(c => c.total == total).ToList();
        }

        public List<Compras> GetPorProveedor(int cod_proveedor)
        {
            return db.Compras.Where(c => c.cod_proveedor == cod_proveedor).ToList();
        }

        //Actualizar total
        public void ActualizarTotal(int cod_compra, int total)
        {
            Compras compras = this.Get(cod_compra);
            compras.total = total;

            db.SaveChanges();
        }

        //Get
        public Compras Get(int cod_compra)
        {
            Compras compra = db.Compras.Where(c => c.cod_compra == cod_compra).FirstOrDefault();
            return compra;
        }

        //Get ultima comrpa
        public int GetUltima()
        {
            int cod_compra = db.Compras.Max(c => c.cod_compra);
            return cod_compra;
        }

        //Delete
        public void Remove(int cod_compra)
        {
            Compras compras = this.Get(cod_compra);

            db.Compras.Remove(compras);
            db.SaveChanges();
        }
        
    }
}
