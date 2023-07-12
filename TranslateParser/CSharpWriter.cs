using System.Text;

namespace TranslateParser
{
    public class CSharpWriter
    {

        public string Path
        {
            get;
        }

        public StreamWriter? Writer
        {
            get;
        }

        public CSharpWriter(string path)
        {
            Path = path;

            try
            {
                Writer = new StreamWriter(Path, false, Encoding.UTF8);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open '" + Path + "' " + e.Message + " " + e.Source);
            }
        }

        internal bool WriteLine(string line)
        {
            try
            {
                if (Writer == null) throw new NullReferenceException("Writer is null");
                Writer.WriteLine(line);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot write to '" + Path + "' " + e.Message + " " + e.Source);
            }

            return false;
        }

        internal void Close()
        {
            try
            {
                if (Writer == null)
                    throw new NullReferenceException("Writer is null");
                Writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot close '" + Path + "' " + e.Message + " " + e.Source);
            }
        }
    }
}