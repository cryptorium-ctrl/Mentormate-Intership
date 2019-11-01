namespace App.Services
{
    using App.Constants;
    using App.Interfaces;
    using System;
    using System.IO;

    public class DataWriter : IDataWriter
    {
        private object locker;

        public DataWriter()
        {
            this.locker = new object();
        }

        public void WriteToFile(string output, string path)
        {
            try
            {
                if (path.EndsWith('\\'))
                    path.TrimEnd('\\');
                    
                lock (this.locker)
                {
                    if (path.IndexOf(".csv") < 0)
                    {
                        if (File.Exists(path))
                            File.AppendAllText(path, output);
                        else
                            File.AppendAllText(path + @"\result.csv", output);
                    }
                    else
                    {
                        if (File.Exists(path))
                            File.AppendAllText(path, output);
                        else
                        {
                            File.AppendAllText(path, output);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception(StringMessages.PathNotValid);
            }            
        }
    }
}