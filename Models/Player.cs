namespace App.Models
{
    public class Player
    {
        private string name;
        private int playerSince;
        private string position;
        private decimal raiting;

        public Player()
        { }

        public string Name { get => this.name; set => this.name = value; }
        public int PlayerSince { get => this.playerSince; set => this.playerSince = value; }
        public string Position { get => this.position; set => this.position = value; }
        public decimal Raiting { get => this.raiting; set => this.raiting = value; }
    }
}