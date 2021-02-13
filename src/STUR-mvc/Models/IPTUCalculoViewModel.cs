using System.ComponentModel.DataAnnotations;

namespace STUR_mvc.Models
{
    public class IPTUCalculoViewModel
    {
        [Display(Name = "Ano Base")]
        public int AnoBase { get; set; }
        [Display(Name = "Inscrição Imóvel")]
        public int? InscricaoImovel { get; set; }
    }
}
