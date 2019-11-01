namespace App.Models
{
    public class InputData
    {
        private string pathToFile;
        private int maxYears;
        private decimal minRaiting;
        private string outputPath;
        
        public InputData()
        { }

        public string PathToFile { get => this.pathToFile; set => this.pathToFile = value; }
        public int MaxYears { get => this.maxYears; set => this.maxYears = value; }
        public decimal MinRaiting { get => this.minRaiting; set => this.minRaiting = value; }
        public string OutputPath { get => this.outputPath; set => this.outputPath = value; }
    }
}