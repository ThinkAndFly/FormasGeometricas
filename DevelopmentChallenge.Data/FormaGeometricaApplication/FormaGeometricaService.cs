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
                // Hay por lo menos una forma
                // HEADER
                sb.Append($"<h1>{Traducciones.ReporteFormas}</h1>");

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;

                for (var i = 0; i < formas.Count; i++)
                {
                    if (formas[i].Tipo == TipoFormaGeometricaEnum.Cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += formas[i].CalcularArea();
                        perimetroCuadrados += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == TipoFormaGeometricaEnum.Circulo)
                    {
                        numeroCirculos++;
                        areaCirculos += formas[i].CalcularArea();
                        perimetroCirculos += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == TipoFormaGeometricaEnum.TrianguloEquilatero)
                    {
                        numeroTriangulos++;
                        areaTriangulos += formas[i].CalcularArea();
                        perimetroTriangulos += formas[i].CalcularPerimetro();
                    }
                }

                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, TipoFormaGeometricaEnum.Cuadrado));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, TipoFormaGeometricaEnum.Circulo));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, TipoFormaGeometricaEnum.TrianguloEquilatero));

                // FOOTER
                sb.Append($"{Traducciones.Total}:<br/>");
                sb.Append($"{numeroCuadrados + numeroCirculos + numeroTriangulos} {Traducciones.Formas} ");
                sb.Append($"{Traducciones.Perimetro} {(perimetroCuadrados + perimetroTriangulos + perimetroCirculos):#.##} ");
                sb.Append($"{Traducciones.Area} {(areaCuadrados + areaCirculos + areaTriangulos):#.##} ");
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
                case TipoFormaGeometricaEnum.Circulo:
                     return cantidad == 1 ? Traducciones.Circulo : Traducciones.Circulos;
                case TipoFormaGeometricaEnum.TrianguloEquilatero:
                    return cantidad == 1 ? Traducciones.Triangulo : Traducciones.Triangulos;
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
