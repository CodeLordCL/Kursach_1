namespace Kursach_1.Managers
{
    internal class Reader
    {
        public string ReadFile(string file)
        {
            string s = "";
            StreamReader sr = new StreamReader(file);

            while (!sr.EndOfStream)
            {
                s += sr.ReadLine();
            }

            sr.Close();
            return s;
        }
    }
}
