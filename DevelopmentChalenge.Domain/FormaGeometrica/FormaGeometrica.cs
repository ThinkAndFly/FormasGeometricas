using DevelopmentChalenge.Domain.Enums;

namespace DevelopmentChalenge.Domain.FormaGeometrica
{
    public abstract class FormaGeometrica
    {
        protected decimal _lado { get; }

        protected FormaGeometrica(decimal lado)
        {
            _lado = lado;
        }

        public abstract TipoFormaGeometricaEnum Tipo { get; }
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
    }
}
