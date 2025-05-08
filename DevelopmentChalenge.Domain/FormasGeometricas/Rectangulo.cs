using DevelopmentChalenge.Domain.Enums;

namespace DevelopmentChalenge.Domain.FormasGeometricas
{
    public class Rectangulo : FormaGeometrica
    {
        protected decimal Lado2 { get; }
        
        public Rectangulo(decimal lado, decimal lado2) : base(lado) { 
            Lado2 = lado2;
        }

        public override TipoFormaGeometricaEnum Tipo => TipoFormaGeometricaEnum.Rectangulo;

        public override decimal CalcularArea()
        {
            return Lado * Lado;
        }

        public override decimal CalcularPerimetro()
        {
            return Lado * 2 + Lado2 * 2;
        }
    }
}
