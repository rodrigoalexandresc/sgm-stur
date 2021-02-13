using System;

namespace STUR_mvc.Models
{
    public class InfoGeo
    {
        public int Id { get; set; }
        public string InscricaoImovel { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int AreaConstruida { get; set; }
        public int AreaTerreno { get; set; }
    }
}
