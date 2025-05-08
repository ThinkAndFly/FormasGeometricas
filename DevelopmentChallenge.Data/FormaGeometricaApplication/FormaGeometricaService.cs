/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChalenge.Domain.DTO;
using DevelopmentChalenge.Domain.Enums;
using DevelopmentChalenge.Domain.FormasGeometricas;
using DevelopmentChalenge.Domain.Locale;
using DevelopmentChallenge.Domain.FormasGeometricas;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace DevelopmentChallenge.Application.FormaGeometricaApplication
{
    public class FormaGeometricaService
    {
        public FormaGeometricaService()
        {
        }

        public static string Imprimir(List<FormaGeometrica> formas, IdomasEnum idioma)
        {
            SetearIdioma(idioma);

            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append($"<h1>{Traducciones.ListaVacia}</h1>");
            }
            else
            {
                sb.Append($"<h1>{Traducciones.ReporteFormas}</h1>");

                var datosFormas = new Dictionary<TipoFormaGeometricaEnum, ImprimirDTO>();

                foreach (TipoFormaGeometricaEnum tipo in Enum.GetValues(typeof(TipoFormaGeometricaEnum)))
                {
                    datosFormas.Add(tipo, new ImprimirDTO());
                }

                for (var i = 0; i < formas.Count; i++)
                {
                    datosFormas[formas[i].Tipo].Numero++;
                    datosFormas[formas[i].Tipo].Area += formas[i].CalcularArea();
                    datosFormas[formas[i].Tipo].Perimetro += formas[i].CalcularPerimetro();
                }

                foreach(TipoFormaGeometricaEnum tipo in Enum.GetValues(typeof(TipoFormaGeometricaEnum)))
                {
                    sb.Append(ObtenerLinea(datosFormas[tipo].Numero, datosFormas[tipo].Area, datosFormas[tipo].Perimetro, tipo));
                }

                // FOOTER
                sb.Append($"{Traducciones.Total}:<br/>");
                sb.Append($"{datosFormas.Sum(f => f.Value.Numero)} {Traducciones.Formas} ");
                sb.Append($"{Traducciones.Perimetro} {(datosFormas.Sum(f => f.Value.Perimetro)):#.##} ");
                sb.Append($"{Traducciones.Area} {(datosFormas.Sum(f => f.Value.Area)):#.##}");
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, TipoFormaGeometricaEnum tipo)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} {TraducirForma(tipo, cantidad)} | {Traducciones.Area} {area:#.##} | {Traducciones.Perimetro} {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(TipoFormaGeometricaEnum tipo, int cantidad)
        {
            switch (tipo)
            {
                case TipoFormaGeometricaEnum.Cuadrado:
                    return cantidad == 1 ? Traducciones.Cuadrado : Traducciones.Cuadrados;
                case TipoFormaGeometricaEnum.TrianguloEquilatero:
                    return cantidad == 1 ? Traducciones.Triangulo : Traducciones.Triangulos;
                case TipoFormaGeometricaEnum.Circulo:
                    return cantidad == 1 ? Traducciones.Circulo : Traducciones.Circulos;
                case TipoFormaGeometricaEnum.Rectangulo:
                    return cantidad == 1 ? Traducciones.Rectangulo : Traducciones.Rectangulos;
            }

            return string.Empty;
        }

        public static FormaGeometrica CrearForma(TipoFormaGeometricaEnum tipo, decimal ancho)
        {
            switch (tipo)
            {
                case TipoFormaGeometricaEnum.Circulo:
                    return new Circulo(ancho);
                case TipoFormaGeometricaEnum.Cuadrado:
                    return new Cuadrado(ancho);
                case TipoFormaGeometricaEnum.TrianguloEquilatero:
                    return new TrianguloEquilatero(ancho);
                default:
                    throw new NotImplementedException();
            }
        }

        public static FormaGeometrica CrearForma(TipoFormaGeometricaEnum tipo, decimal ancho, decimal largo)
        {
            switch (tipo)
            {
                case TipoFormaGeometricaEnum.Rectangulo:
                    return new Rectangulo(ancho, largo);
                default:
                    throw new NotImplementedException();
            }
        }

        private static void SetearIdioma(IdomasEnum idioma)
        {
            switch(idioma)
            {
                case IdomasEnum.Castellano:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
                    break;
                case IdomasEnum.Ingles:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                    break;
                case IdomasEnum.Italiano:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("it");
                    break;
            }
        }
    }
}
