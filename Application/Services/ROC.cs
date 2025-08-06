using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.DTOs;

namespace Application.Services
{
    public class ROC
    {
        public List<string> CalculoROC(DatosListDTO datos)
        {
            const int n = 5;

            var resultados = new List<string>();

            var datosOrdenados = datos.Datos
                                      .OrderBy(d => d.fecha)
                                      .Select(d => d.valor)
                                      .ToList();

            for(int i = 0; i < n; i++)
            {
                resultados.Add($"t={i + 1}, Precio={datosOrdenados[i]}, ROC({n}) = N/A");
            }   

            for (int t = n; t < datosOrdenados.Count; t++)
            {
                decimal valorActual = datosOrdenados[t];
                decimal valorPasado = datosOrdenados[t - n];

                decimal roc = ((valorActual / valorPasado) - 1) * 100;
                resultados.Add($"t={t + 1}, Precio={valorActual}, ROC({n}) = {roc:F2}%");
            }

            return resultados;
        }
    }
}
