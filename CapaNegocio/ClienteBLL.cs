using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;


namespace CapaNegocio
{
    public class ClienteBLL
    {
        NegocioPlayEntities bd = new NegocioPlayEntities();

        //Crud de los clientes


        //Añadir cliente
        public void Add(string nombre, string numero, bool deudor, int deuda)
        {
            Clientes nuevo = new Clientes();
            nuevo.nom_cliente = nombre;
            nuevo.telefono_cliente = numero;
            nuevo.estado = deudor;
            nuevo.deuda = deuda;

            bd.Clientes.Add(nuevo);
            bd.SaveChanges();
        }

        //Listar cliente
        public List<Clientes> GetClientes()
        {
            return bd.Clientes.ToList();
        }
        //Filtros de listado
        //Si tiene deuda pendiente
        public List<Clientes> GetDeudores()
        {
            return bd.Clientes.Where(c => c.estado == true).ToList();
        }
        //Por deuda pendiente
        public List<Clientes> GetClientePorDeuda(int deuda)
        {
            return bd.Clientes.Where(c => c.deuda >= deuda).ToList();
        }
        //Por nombre
        public List<Clientes> GetClientePorNombre(string nombre)
        {
            return bd.Clientes.Where(c => c.nom_cliente.Contains(nombre)).ToList();
        }
        //Por id
        public Clientes Get(int cod_cliente)
        {
            Clientes cliente = bd.Clientes.Where(c => c.cod_cliente == cod_cliente).FirstOrDefault();
            return cliente;
        }
        
        //Actualizar deuda
        public void ActualizarDeuda(Clientes cliente,int deuda)
        {
            //Se busca el cliente y se actualiza su deuda
            Clientes c = this.Get(cliente.cod_cliente);
            c.deuda = c.deuda + deuda;
            //si la nueva deuda es 0, tambien se actualiza su estado de deudor a falso
            if (deuda == 0) { c.estado = false; };
            //se manda el query a la bd
            bd.SaveChanges();
        }
        public void ActualizarTelefono(Clientes cliente, string telefono)
        {
            //Se busca el cliente y se actualiza su telefono
            Clientes c = this.Get(cliente.cod_cliente);
            c.telefono_cliente = telefono;
   
            //se manda el query a la bd
            bd.SaveChanges();
        }

        //Get codigo por nombre
        public int CodigoPorNombre(string nombre)
            {
                Clientes cliente = bd.Clientes.Where(c => c.nom_cliente.Contains(nombre)).FirstOrDefault();
            if (cliente != null)
            {
                return cliente.cod_cliente;
            }
            else return 0;
            }

        
    }
}
