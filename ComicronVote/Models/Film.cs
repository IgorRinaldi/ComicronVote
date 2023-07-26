namespace ComicronVote.Models
{
    public class Film
    {
        public Guid Id { get; set; }

        public string Titolo { get; set; }

        public string Regista { get; set; }

        public string Codice { get; set; }

        public IEnumerable<Voto> Voti { get; set; } = new List<Voto>();
    }
}
