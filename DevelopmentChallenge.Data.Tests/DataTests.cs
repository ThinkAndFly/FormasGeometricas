﻿using DevelopmentChalenge.Domain.Enums;
using DevelopmentChalenge.Domain.FormasGeometricas;
using DevelopmentChallenge.Application.FormaGeometricaApplication;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DevelopmentChallenge.Application.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometricaService.Imprimir(new List<FormaGeometrica>(), IdomasEnum.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometricaService.Imprimir(new List<FormaGeometrica>(), IdomasEnum.Ingles));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                FormaGeometricaService.Imprimir(new List<FormaGeometrica>(), IdomasEnum.Italiano));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> { FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Cuadrado, 5)};

            var resumen = FormaGeometricaService.Imprimir(cuadrados, IdomasEnum.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectangulo()
        {
            var rectangulos = new List<FormaGeometrica> { FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Rectangulo, 5,4) };

            var resumen = FormaGeometricaService.Imprimir(rectangulos, IdomasEnum.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Rectángulo | Area 20 | Perimetro 18 <br/>TOTAL:<br/>1 formas Perimetro 18 Area 20", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Cuadrado, 5),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Cuadrado, 1),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Cuadrado, 3)
            };

            var resumen = FormaGeometricaService.Imprimir(cuadrados, IdomasEnum.Ingles);

            Assert.AreEqual("<h1>Shapes Report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Cuadrado, 5),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Circulo, 3),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.TrianguloEquilatero, 4),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Cuadrado, 2),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.TrianguloEquilatero, 9),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Circulo, 2.75m),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometricaService.Imprimir(formas, IdomasEnum.Ingles);

            Assert.AreEqual(
                "<h1>Shapes Report</h1>2 Squares | Area 29 | Perimeter 28 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposYNuevo()
        {
            var formas = new List<FormaGeometrica>
            {
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Cuadrado, 5),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Circulo, 3),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.TrianguloEquilatero, 4),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Rectangulo, 4,5),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Cuadrado, 2),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.TrianguloEquilatero, 9),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Circulo, 2.75m),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.TrianguloEquilatero, 4.2m),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Rectangulo, 2,3),
            };

            var resumen = FormaGeometricaService.Imprimir(formas, IdomasEnum.Ingles);

            Assert.AreEqual(
                "<h1>Shapes Report</h1>2 Squares | Area 29 | Perimeter 28 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>2 Rectangles | Area 26 | Perimeter 28 <br/>TOTAL:<br/>9 shapes Perimeter 125,66 Area 117,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Cuadrado, 5),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Circulo, 3),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.TrianguloEquilatero, 4),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Cuadrado, 2),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.TrianguloEquilatero, 9),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Circulo, 2.75m),
                FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometricaService.Imprimir(formas, IdomasEnum.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestCrearUnRectanguloSinLado()
        {
            var ex = Assert.Throws<NotImplementedException>(() =>
            {
                new List<FormaGeometrica> { FormaGeometricaService.CrearForma(TipoFormaGeometricaEnum.Rectangulo, 5) };
            });
        }
    }
}
