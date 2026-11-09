namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        private Quarto _quartoSelecionado = new();
        private int _qtdAdultos = 1;
        private int _qtdCriancas;

        public Quarto QuartoSelecionado
        {
            get => _quartoSelecionado;
            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value));

                _quartoSelecionado = value;
            }
        }

        public int QtdAdultos
        {
            get => _qtdAdultos;
            set
            {
                if (value < 1)
                    throw new ArgumentException("A hospedagem deve ter pelo menos um adulto.");

                _qtdAdultos = value;
            }
        }

        public int QtdCriancas
        {
            get => _qtdCriancas;
            set
            {
                if (value < 0)
                    throw new ArgumentException("A quantidade de crianças não pode ser negativa.");

                _qtdCriancas = value;
            }
        }

        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        public bool DatasValidas => DataCheckOut.Date > DataCheckIn.Date;

        public int Estadia =>
            DatasValidas
                ? (DataCheckOut.Date - DataCheckIn.Date).Days
                : 0;

        public double ValorTotal =>
            Estadia * QuartoSelecionado.ValorDiaria;
    }
}