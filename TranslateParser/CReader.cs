namespace TranslateParser
{
    public class CReader
    {
        public string Path
        {
            get;
        }

        public StreamReader? Reader
        {
            get;
        }

        public CReader(string path)
        {
            Path = path;

            try
            {
                Reader = new StreamReader(Path, System.Text.Encoding.UTF8);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open '" + Path + "' " + e.Message + " " + e.Source);
            }
        }

        internal string? ReadLine()
        {
            try
            {
                if (Reader == null) throw new NullReferenceException("Reader is null.");
                return Reader.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot read from '" + Path + "' " + e.Message + " " + e.Source);
            }
            return null;
        }

        internal void Close()
        {
            try
            {
                if (Reader == null)
                    throw new NullReferenceException("Reader is null.");
                Reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot close '" + Path + "' " + e.Message + " " + e.Source);
            }
        }

    }
}
