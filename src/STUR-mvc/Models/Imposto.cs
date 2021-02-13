using System;

namespace STUR_mvc.Models {
    public class Imposto {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string InscricaoImovel { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Chave { get; set; }
        public string Descricao { get; set; }
        public decimal AreaConstruida { get; set; }
        public decimal AreaTerreno { get; set; }
    }
}