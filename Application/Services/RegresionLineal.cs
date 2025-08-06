using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.DTOs;

namespace Application.Services
{
    public class RegresionLineal
    {
        public List<string> CalculoRegresionLineal(DatosListDTO datos)
        {
            const int n = 20;
            const int dia21 = 21;
            decimal m = 0;
            decimal b = 0;

            var valores = datos.Datos
                .OrderBy(d => d.fecha)
                .Take(n)
                .Select(d => d.valor)   
                .ToArray(); 


            decimal[] x = new decimal[n];
            decimal[] y = valores;
            decimal[] xy = new decimal[n];
            decimal[] x2 = new decimal[n];

            for (int i = 0; i < n; i++)
            {
                x[i] = i + 1;
                xy[i] = x[i] * y[i];
                x2[i] = x[i] * x[i];
            }

            decimal sumX = x.Sum();
            decimal sumY = y.Sum();
            decimal sumXY = xy.Sum();
            decimal sumX2 = x2.Sum();

            decimal mediaX = sumX / n;
            decimal mediaY = sumY / n;


            m = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            b = (mediaY - m * mediaX);

            decimal prediccion = m * dia21 + b;

            string tendencia = "";
            if (m > 0) tendencia = "Alcista";
            else if (m < 0) tendencia = "Bajista";
            else tendencia = "Sin tendencia clara";


            return new List<string> { $"Pendiente (m): {Math.Round(m, 2)}, Intersección (b): {Math.Round(b, 2)}, día 21: {Math.Round(prediccion, 2)}, la tendencia es {tendencia}" };
        }
    }
}
