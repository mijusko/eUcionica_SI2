namespace eUcionica.Models
{
	public class Predmet
	{
		public int ID { get; set; }
		public string? NazivPredmeta { get; set; }

		public ICollection<Pitanje> Pitanja { get; set; } = new List<Pitanje>();
		public ICollection<Oblast> Oblasti { get; set; } = new List<Oblast>();

	}
}
