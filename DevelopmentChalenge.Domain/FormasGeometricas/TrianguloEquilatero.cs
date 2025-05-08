using DevelopmentChalenge.Domain.Enums;
using DevelopmentChalenge.Domain.FormasGeometricas;
using System;

namespace DevelopmentChallenge.Domain.FormasGeometricas
{
    public class TrianguloEquilatero : FormaGeometrica
    {
        public TrianguloEquilatero(decimal lado) : base(lado) { }

        public override TipoFormaGeometricaEnum Tipo => TipoFormaGeometricaEnum.TrianguloEquilatero;

        public override decimal CalcularArea()
        {
            return (decimal)Math.Sqrt(3) / 4 * Lado * Lado;
        }

        public override decimal CalcularPerimetro()
        {
            return Lado * 3;
        }
    }
}
