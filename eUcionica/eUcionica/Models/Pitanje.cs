using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eUcionica.Models
{
	public class Pitanje
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public int PredmetID { get; set; }
		[ForeignKey("PredmetID")]
		public Predmet? Predmet { get; set; }

		public int OblastID { get; set; }
		[ForeignKey("OblastID")]
		public Oblast? Oblast { get; set; }

		public string? NivoTezine { get; set; }

		public string? PitanjeText { get; set; }

		public string? TacanOdgovor { get; set; }


		[NotMapped]
		public string? UnetiOdgovor { get; set; }
	}
}
