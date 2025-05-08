using DevelopmentChalenge.Domain.Enums;

namespace DevelopmentChalenge.Domain.FormasGeometricas
{
    public abstract class FormaGeometrica
    {
        protected decimal Lado { get; }

        protected FormaGeometrica(decimal lado)
        {
            Lado = lado;
        }

        public abstract TipoFormaGeometricaEnum Tipo { get; }
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
    }
}
