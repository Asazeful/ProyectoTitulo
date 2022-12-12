using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class ProductoBLL
    {
        NegocioPlayEntities db = new NegocioPlayEntities();

        //Crud de los productos

        //Añadir Producto

        public void Add(string nom_producto, string categoria, int precio_compra, int precio_venta, int stock)
        {
            Producto producto = new Producto();

            producto.nom_producto = nom_producto;
            producto.categoria = categoria;
            producto.precio_compra = precio_compra;
            producto.precio_venta = precio_venta;
            producto.stock = stock;

            db.Producto.Add(producto);

            db.SaveChanges();
        }

        //Listar productos

        public List<Producto> GetProductos()
        {
            return db.Producto.ToList();
        }
        //Filtros:
        //Por nombre

        public List<Producto> GetProductoPorNombre(string nombre)
        {
            return db.Producto.Where(p => p.nom_producto.Contains(nombre)).ToList();
        }

        //Por precio de venta

        public List<Producto> GetProductoPorPrecio(int precio_venta)
        {
            return db.Producto.Where(p => p.precio_venta == precio_venta).ToList();
        }

        //Por stock

        public List<Producto> GetProductoPorStock(int stock)
        {
            return db.Producto.Where(p => p.stock <= stock).ToList();
        }

        //Por id
        public Producto GetProducto(int id)
        {
            Producto producto = db.Producto.Where(p => p.cod_producto == id).FirstOrDefault();
            return producto;
        }
        //Por categoria
        public List<Producto>GetProductoPorCategoria(string categorias)
        {
            return db.Producto.Where(p => p.categoria == categorias).ToList();
        }

        //Actualizaciones:
        //Stock
        public void RestarStock(int cod_producto, int stock)
        {
            Producto p = this.GetProducto(cod_producto);

            p.stock = p.stock - stock;

            db.SaveChanges();
        }
        public void SumarStock(int cod_producto, int stock)
        {
            Producto p = this.GetProducto(cod_producto);

            p.stock = p.stock + stock;

            db.SaveChanges();
        }
        public void ActualizarPVenta(Producto producto, int pventa)
        {
            Producto p = this.GetProducto(producto.cod_producto);
            p.precio_venta = pventa;

            db.SaveChanges();
        }
        public void ActualizarPCompra(Producto producto, int pcompra)
        {
            Producto p = this.GetProducto(producto.cod_producto);
            p.precio_compra = pcompra;

            db.SaveChanges();
        }
        public void ActualizarCategoria(Producto producto,string categoria)
        {
            Producto p = this.GetProducto(producto.cod_producto);
            p.categoria = categoria;

            db.SaveChanges();
        }


    }
    }
