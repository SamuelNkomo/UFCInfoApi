// Models/Fighter.cs
namespace UFCInfoApi.Models
{
    public class Fighter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string WeightClass { get; set; }
        public string FightRecord { get; set; }  // Format: "Win-Loss-Draw"
    }
}
