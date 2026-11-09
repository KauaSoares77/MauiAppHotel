namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; } = new Quarto();
        public int QtdAdultos { get; set; }
        public int QtdCriancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        // Propriedades calculadas, exibidas na tela de resumo via Binding
        public int Estadia => (DataCheckOut - DataCheckIn).Days;

        public double ValorTotal => Estadia * QuartoSelecionado.ValorDiaria;
    }
}