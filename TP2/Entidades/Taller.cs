using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public static sealed class Taller
    {
        static List<Vehiculo> vehiculos;
        static int espacioDisponible;
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }

        #region "Constructores"
        static Taller()
        {
            Taller.vehiculos = new List<Vehiculo>();
        }
        public static int EspacioDisponible         
        {
            get
            {
                return Taller.espacioDisponible;
            }
            set { Taller.espacioDisponible = value; }
            
        }
        #endregion



        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public static string ToString()
        {
            return Taller.Listar(ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar( ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", Taller.vehiculos.Count, Taller.espacioDisponible);
            sb.AppendLine("");

            foreach (Vehiculo v in Taller.vehiculos)
            {
                
                if (v is Suv && tipo == ETipo.SUV)
                {
                    sb.AppendLine(v.Mostrar());
                }
                else
                {
                    if (v is Sedan && tipo == ETipo.Sedan)
                    {
                        sb.AppendLine(v.Mostrar());
                    }
                    else
                    {
                        if (v is Ciclomotor && tipo == ETipo.Ciclomotor)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        else
                        {
                            if (tipo == ETipo.Todos)
                            {
                                sb.AppendLine(v.Mostrar());
                            }
                        }
                      
                        
                                                   
                    }
                }

            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static void AgregarVehiculo(Vehiculo vehiculo)
        {
            bool vehiculoYaEnLista = false;

            if (Taller.vehiculos.Count < Taller.espacioDisponible)
            { 
                foreach (Vehiculo v in Taller.vehiculos)
                {
                    if (v == vehiculo)
                    {
                        vehiculoYaEnLista = true;
                        break;
                    }
                }

                if (!vehiculoYaEnLista)
                {
                    Taller.vehiculos.Add(vehiculo);
                }
            }
                                 
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static void QuitarVehiculo (Vehiculo vehiculo)
        {
            foreach ( Vehiculo v in Taller.vehiculos)
            {
                if (v == vehiculo)
                {
                    Taller.vehiculos.Remove(vehiculo);
                    break;
                }
            }         
           
        }
        #endregion
    }
}
