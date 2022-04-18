namespace Kursach_1.Managers
{
    internal class Wrighter
    {

        public void WrightFile(string s, string file)
        {
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(s);
            sw.Close();
        }
    }
}
