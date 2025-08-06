using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.DTOs;

namespace Application.Services
{
    public class MediaMovilSimple
    {
        public List<string> CalculoMediaMovilSimple(DatosListDTO datos)
        {
            decimal smaCorta = SMACorta(datos);
            decimal smaLarga = SMALarga(datos);

            if (smaCorta > smaLarga)
            {
                return new List<string> { $"La tendencia es alcista, resultados: SMA corta = {smaCorta}, SMA larga = {smaLarga}" };
            }
            else if (smaCorta < smaLarga)
            {
                return new List<string> { $"La tendencia es bajista, resultados: SMA corta = {smaCorta}, SMA larga = {smaLarga}" };
            }
            else
            {
                return new List<string> { "No hay tendencia clara (ambas SMAs son iguales)" };
            }
        }

        public decimal SMACorta(DatosListDTO datos)
        {
            var ultimos5 = datos.Datos
                                .Select(d => d.valor)
                                .Take(5)
                                .ToList();

            if (!ultimos5.Any()) return 0;

            return ultimos5.Average();
        }

        public decimal SMALarga(DatosListDTO datos)
        {
            var ultimos20 = datos.Datos
                                 .Select(d => d.valor)
                                 .Take(20)
                                 .ToList();

            foreach(var item in datos.Datos)
            {
                Debug.WriteLine(item.fecha + " - " + item.valor);
            }

            Debug.WriteLine("Valores SMA larga: " + string.Join(", ", ultimos20));

            if (!ultimos20.Any()) return 0;

            return ultimos20.Average();
        }
    }

}
