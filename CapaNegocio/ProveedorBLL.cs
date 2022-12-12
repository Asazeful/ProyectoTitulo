using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class ProveedorBLL
    {
        NegocioPlayEntities db = new NegocioPlayEntities();

        //añadir proveedor
        public void Add(string nom_proveedor, string telefono)
        {
            Proveedor proveedor = new Proveedor();

            proveedor.nom_proveedor = nom_proveedor;
            proveedor.telefono_proveedor = telefono;

            db.Proveedor.Add(proveedor);
            db.SaveChanges();
        }

        //Listar
        public List<Proveedor> GetProveedores()
        {
            return db.Proveedor.ToList();
        }

        //por nombre
        public List<Proveedor> GetPorNombre(string nombre)
        {
            return db.Proveedor.Where(p => p.nom_proveedor == nombre).ToList();
            
        }

        //azctualizat telefono
        public void ActualizarTelefono(int cod_proveedor, string telefono)
        {
            Proveedor proveedor = this.Get(cod_proveedor);

            proveedor.telefono_proveedor = telefono;
            db.SaveChanges();
        }

        //get
        public Proveedor Get(int cod_proveedor)
        {
            Proveedor proveedor = db.Proveedor.Where(p => p.cod_proveedor == cod_proveedor).FirstOrDefault();
            return proveedor;
        }

        //delete
        public void Remove(int cod_proveedor)
        {
            Proveedor proveedor = this.Get(cod_proveedor);

            db.Proveedor.Remove(proveedor);
            db.SaveChanges();
        }

    }
}
