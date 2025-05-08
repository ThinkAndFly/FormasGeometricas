using DevelopmentChalenge.Domain.Enums;
using DevelopmentChalenge.Domain.FormasGeometricas;

namespace DevelopmentChallenge.Domain.FormasGeometricas
{
    public class Cuadrado : FormaGeometrica
    {
        public Cuadrado(decimal lado) : base(lado) { }

        public override TipoFormaGeometricaEnum Tipo => TipoFormaGeometricaEnum.Cuadrado;

        public override decimal CalcularArea()
        {
           return Lado * Lado;
        }

        public override decimal CalcularPerimetro()
        {
            return Lado * 4;
        }
    }
}
