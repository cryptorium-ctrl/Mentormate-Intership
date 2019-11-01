using System.Runtime.Serialization;

namespace App.Constants
{
    public static class StringMessages
    {
        //Initial messages.
        #region
        public const string ProvidePathToFile = "Please type in the path to the json file: ";
        public const string ProvideMaxNumYears = "Please type in the maximum number of years the player has played in the league to qualify: ";
        public const string ProvideMinRaiting = "Please type in the minimum rating the player should have to qualify: ";
        public const string ProvideOutputPath = "Please type in the path to the CSV (comma separated value) file: ";
        public const string WriteComplete = "Writing to file is completed.";
        #endregion

        //Error messages.
        #region
        public const string FileNotExisting = "Please provide correct path to data file. File does not exist.";
        public const string PathNotValid = "Please provide correct path.";
        public const string ErrorCheckInput = "Please check your input";
        #endregion
    }
}
