using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public delegate void TipoFuncionCallbackEliminar();

    public interface IListaUsuariosListener
    {
        void AvisameAlCrear();
        //void AvisameAlAbdicar();
    }
    public class ListaUsuarios : IGestionUsuarios {
        protected List<Persona> lista;
        private IListaUsuariosListener observador;
        public ListaUsuarios()
        {
            this.lista = new List<Persona>();
        }
        public void RegistrarObservador(IListaUsuariosListener observador)   {
            this.observador = observador;
        }
        public void DesregistrarObservador() {
        }
        public Persona this[int indice]
        {
            get
            {
                Persona per;
                if (Obtener(indice, out per))
                {
                    return per;
                } else
                    throw new ArgumentNullException("Fallo al obtener!");
            }
            set
            {
                this.Modificar(indice, value);
            }
        }
        public Persona this[string nombre]   {
            get   {                
                foreach (Persona persona in lista)   {
                    if (persona.Nombre.ToUpper().Trim().Replace("  ", " ")
                           .Contains(nombre.Trim().Replace("  ", " ").ToUpper()))
                        return persona;
                }
                return null;
            }
            set    {
                if (value != null)  {
                    Persona persona = this[nombre];
                    if (persona != null)
                    {
                        int indice = this.lista.IndexOf(persona);
                        this.lista[indice] = value;
                    } else {
                        Crear(value);
                    }
                }
            }
        }
        public virtual bool Crear(Persona persona)
        {
            if (persona != null && !lista.Contains(persona))
            {
                lista.Add(persona);
                if(observador!=null)
                    observador.AvisameAlCrear();
                return lista.Contains(persona);
            }
            else
                return false;
        }
        public virtual bool Eliminar(int indice, TipoFuncionCallbackEliminar funCallbackAlEliminar)
        {
            if (Eliminar(indice))
            {
                funCallbackAlEliminar();
                return true;
            } else
            {
                return false;
            }
        }
        public virtual bool Eliminar(int indice)
        {
            if ((indice >= 0) && (indice < this.lista.Count))
            {
                this.lista.RemoveAt(indice);
                return true;
            }
            return false;
        }
        public virtual bool Eliminar(Persona persona)
        {
            return this.lista.Remove(persona);
        }
        public bool Listar(out List<Persona> lista)
        {
            try
            {
                lista = this.lista.ToList<Persona>();
            }
            catch (Exception e)
            {
                lista = null;
                return false;
            }
            return true;
        }
        public bool Listar(out Persona[] lista)  {
            try   {
                lista = this.lista.ToArray<Persona>();
            } catch(Exception e) {
                lista = null;
                return false;
            }
            return true;
        }        
        public bool Modificar(int indice, Persona persona)
        {
            if (persona != null)     {
                if (indice < this.lista.Count
                    && this.lista[indice] != null)    {
                    this.lista[indice] = persona;
                }    else    {
                    Crear(persona);
                }
                return true;
            }
            else   {
                return false;
            }
        }
        public bool Obtener(int id, out Persona persona)
        {
            if (id >= 0 && id < this.lista.Count) {
                persona = this.lista[id];
                return true;
            } else {
                persona = null;
                return false;
            }
        }
        public bool Buscar(out List<Persona> lista, Persona personaCampos)    {

            bool porNombre = personaCampos.Nombre != null;
            bool porEdad = personaCampos.Edad > 0;
            bool encontradoNombre = false;
            bool encontradoEdad = false;
            List<Persona> listaBuscada = new List<Persona>();

            foreach (Persona p in this.lista)     {
                encontradoNombre = !porNombre || (porNombre &&
                    p.Nombre.ToUpper().Trim().Contains(
                        personaCampos.Nombre.ToUpper().Trim()));
                encontradoEdad = !porEdad || (porEdad && p.Edad == personaCampos.Edad);
                if (encontradoNombre && encontradoEdad) {
                    listaBuscada.Add(p);                    
                }
            }
            lista = listaBuscada;
            return listaBuscada.Count > 0;
        }
        /// <summary>
        /// Como el finalize() en  Java. Es llamado al eliminar el objeto.
        /// </summary>
        ~ListaUsuarios()   {
            this.lista.Clear();
            //observador.AvisameAlAbdicar();            
        }
    }
}
