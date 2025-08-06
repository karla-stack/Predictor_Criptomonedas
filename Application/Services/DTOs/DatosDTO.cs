using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DTOs
{
    public class DatosDTOs
    {

        public required DateOnly fecha { get; set; }
        public required decimal valor { get; set; }

        public string Modo { get; set; } = "MediaMovilSimple";
    }
}
