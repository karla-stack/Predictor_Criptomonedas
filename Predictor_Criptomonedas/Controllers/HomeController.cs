using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using Application.Repositories;
using Application.Services;
using Application.Services.DTOs;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Predictor_Criptomonedas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Modos()
        {
            var modoActual = DatosRepository.ObtenerModoActual();
            var modelo = new DatosViewModel { Modo = modoActual };
            return View(modelo);
        }

        public IActionResult Index()
        {
            var model = new DatosViewModel
            {
                Datos = Enumerable.Range(0, 20).Select(_ => new DatoInput()).ToList(),
                Modo = TempData["ModoSeleccionado"] as string 
            };

            TempData.Keep("ModoSeleccionado");
            return View(model);
        }


        [HttpPost]  
        public IActionResult GuardarModo(DatosViewModel modelo)
        {
            DatosRepository.GetInstancia(modelo.Modo);
            TempData["ModoSeleccionado"] = modelo.Modo; // <--- GUARDA el modo
            return RedirectToAction("Index");
        }

        
        /*
        [HttpPost]
        public IActionResult Index(DatosViewModel viewModel)
        {

            if(ModelState.IsValid)
            {
                if(viewModel.Datos.Count != null)
                {
                    Debug.WriteLine($"Cantidad de datos recibidos: {viewModel.Datos.Count}");

                    var datosOrdenados = viewModel.Datos.OrderByDescending(d => d.fecha).ToList();    

                    foreach (var item in datosOrdenados)
                    {
                        Debug.WriteLine($"Fecha: {item.fecha}, Valor: {item.valor}");
                    }
                }

                else
                {
                    Debug.Assert(false, "La lista de datos está vacía o nula.");    
                }



               return View("Index", viewModel);

            }

            return View(viewModel);

        } */


        [HttpPost]
        public IActionResult Index(DatosListDTO datosDTO, DatosViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.Modo))
            {
                viewModel.Modo = TempData["ModoSeleccionado"] as string
                                 ?? DatosRepository.ObtenerModoActual()
                                 ?? "MediaMovilSimple";
            }

            TempData.Keep("ModoSeleccionado");

            var datosOrdenados = viewModel.Datos.OrderByDescending(d => d.fecha).ToList();


            // Map DatosViewModel.Datos to DatosListDTO.Datos
            var datos = datosOrdenados.Select(d => new DatosDTOs
            {
                fecha = d.fecha ?? default, 
                valor = d.valor ?? default  
            }).ToList();

            datosDTO.Datos = datos;

            MediaMovilSimple mediaMovilSimple = new MediaMovilSimple();
            RegresionLineal regresionLineal = new RegresionLineal();
            ROC roc = new ROC();

            // Calling the appropriate service method based on the selected mode :p
            if (viewModel.Modo == "MediaMovilSimple")
            {
               var resultado =  mediaMovilSimple.CalculoMediaMovilSimple(datosDTO);
                viewModel.ResultadosLista = resultado;  
            }
            else if (viewModel.Modo == "RegresionLineal")
            {
                var resultado = regresionLineal.CalculoRegresionLineal(datosDTO);
                viewModel.ResultadosLista = resultado;
            }
            else if (viewModel.Modo == "ROC")
            {
               var resultado =  roc.CalculoROC(datosDTO);
                viewModel.ResultadosLista = resultado;  
            }



            return View(viewModel);
        }

    }
}
