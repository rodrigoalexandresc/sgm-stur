using System;

namespace STUR_mvc.Models {
    public class Imposto {
        public Imposto()
        {

        }

        public Imposto(string inscricaoImovel, DateTime dataVencimento)
        {
            InscricaoImovel = inscricaoImovel;
            DataVencimento = dataVencimento;
            Chave = ImpostoChave.GerarChave(inscricaoImovel, dataVencimento);
        }

        private string GerarChave()
        {
            return InscricaoImovel + DataVencimento.ToString("yyyyMMdd");
        }

        public void CalcularValor()
        {
            Valor = (AreaConstruida * 5.20m) + (AreaTerreno * 1.15m); 
        }

        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string InscricaoImovel { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Chave { get; set; }
        public string Descricao { get; set; }
        public decimal AreaConstruida { get; set; }
        public decimal AreaTerreno { get; set; }
    }

    public class ImpostoChave
    {
        public static string GerarChave(string InscricaoImovel, DateTime DataVencimento)
        {
            return InscricaoImovel + DataVencimento.ToString("yyyyMMdd");
        }
    }
}