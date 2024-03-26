namespace Afprøvning_af_kode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] games = new string[] { "Matador", "Kalaha", "Ludo" };
            foreach(string game in games) {
                Console.WriteLine(game);
            }
            string[] games2 = new string[] { "Matador", "Kalaha", "Ludo", "Uno" };
            foreach (string game in games2)
            {
                Console.WriteLine(game);
            }
            games = games2;
            foreach (string game in games)
            {
                Console.WriteLine(game);
            }
            //tring[] games = new string[] { "Matador", "Kalaha", "Ludo" };
            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }
    }
}