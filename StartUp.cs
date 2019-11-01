namespace App
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using App.Models;
    using System.Text;
    using System.Globalization;
    using App.Interfaces;
    using App.Services;
    using App.Constants;

    public class StartUp
    {
        static void Main()
        {
            var inputData = GatherInitialInfo();
            string data = File.ReadAllText(inputData.PathToFile);

            IList<Player> players = JsonConvert.DeserializeObject<List<Player>>(data);

            var selectedPlayers = players
                .Where(p => (p.Raiting > inputData.MinRaiting) && ((DateTime.Now.Year - p.PlayerSince) < inputData.MaxYears))
                .ToList();

            var resultStr = FilterPlayers(selectedPlayers);

            IDataWriter writer = new DataWriter();
            writer.WriteToFile(resultStr, inputData.OutputPath);
            Console.WriteLine(StringMessages.WriteComplete);
        }

        private static InputData GatherInitialInfo()
        {
            try
            {
                var numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "." };
                var data = new InputData();

                Console.Write(StringMessages.ProvidePathToFile);
                data.PathToFile = Console.ReadLine();

                if (!File.Exists(data.PathToFile)) throw new Exception(StringMessages.FileNotExisting);

                Console.Write(StringMessages.ProvideMaxNumYears);
                data.MaxYears = int.Parse(Console.ReadLine());

                Console.Write(StringMessages.ProvideMinRaiting);
                data.MinRaiting = decimal.Parse(Console.ReadLine().Replace(",", "."), numberFormatInfo);

                Console.Write(StringMessages.ProvideOutputPath);
                data.OutputPath = Console.ReadLine();

                return data;
            }
            catch (Exception)
            {
                throw new Exception(StringMessages.ErrorCheckInput);
            }           
        }

        private static string FilterPlayers(List<Player> selectedPlayers)
        {
            var ouputData = selectedPlayers.Select(p => new
            {
                Name = p.Name,
                Raiting = p.Raiting
            }).OrderByDescending(x => x.Raiting).OrderBy(x => x.Name);

            var exampleObj = selectedPlayers.FirstOrDefault();

            var sb = new StringBuilder();
            sb.AppendLine($"{nameof(exampleObj.Name)}, {nameof(exampleObj.Raiting)}");
            
            foreach (var item in ouputData)
            {
                sb.AppendLine($"{item.Name}, {item.Raiting}");
            }

            return sb.ToString().Trim();            
        }
    }
}