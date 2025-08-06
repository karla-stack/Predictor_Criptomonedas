using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{

    public class DatoInput
    {

        [Required(ErrorMessage = "La fecha es obligatoria")]
        [DataType(DataType.Date)]
        public DateOnly? fecha { get; set; }

        [Required(ErrorMessage = "El valor es obligatorio")]
        [Range(0.01, 10000, ErrorMessage = "El valor debe estar entre 0.01 y 10,000")]
        public decimal? valor { get; set; }
    }
    public class DatosViewModel
    {
        public List<DatoInput> Datos { get; set; }

        public string Modo { get; set; }
        public List<string> ResultadosLista { get; set; } = new();

        public DatosViewModel()
        {
            Datos = new List<DatoInput>();
        } 
    }

}
