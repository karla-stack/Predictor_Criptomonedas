using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.DTOs;
using Application.ViewModels;

namespace Application.Repositories
{
    public sealed class DatosRepository
    {
        private static DatosRepository? instancia;

        public string ModoSeleccionado { get; private set; }

        private DatosRepository(string modo)
        {
            ModoSeleccionado = modo;
        }

        public static DatosRepository GetInstancia(string modo)
        {
            if (instancia == null)
            {
                instancia = new DatosRepository(modo);
            }
            else
            {
                instancia.ModoSeleccionado = modo;
            }

            return instancia;
        }

        public static string ObtenerModoActual()
        {
            return instancia?.ModoSeleccionado ?? "MediaMovilSimple";
        }
    }

}
