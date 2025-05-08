using DevelopmentChalenge.Domain.Enums;
using DevelopmentChalenge.Domain.FormasGeometricas;
using System;

namespace DevelopmentChallenge.Domain.FormasGeometricas
{
    public class Circulo : FormaGeometrica
    {
        public Circulo(decimal lado) : base(lado) { }

        public override TipoFormaGeometricaEnum Tipo => TipoFormaGeometricaEnum.Circulo;

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (Lado / 2) * (Lado / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * Lado;
        }
    }
}
