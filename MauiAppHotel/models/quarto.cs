namespace MauiAppHotel.Models
{
    public class Quarto
    {
        private string _descricao = string.Empty;
        private double _valorDiaria;

        public string Descricao
        {
            get => _descricao;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A descrição do quarto é obrigatória.");

                _descricao = value;
            }
        }

        public double ValorDiaria
        {
            get => _valorDiaria;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("O valor da diária deve ser maior que zero.");

                _valorDiaria = value;
            }
        }
    }
}