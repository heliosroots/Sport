namespace Sport.API.Models
{
    public class Modality
    {
        public Modality(string name, bool team = true)
        {
            Name = name;
            Team = team;
        }

        public int Id { get; set; }
        public string Name { get; set; }        
        public bool Team { get; set; }
    }
}
