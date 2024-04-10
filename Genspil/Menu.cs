using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class Menu
    {

        string title;
        public string Title { get; set; }

        string[] subMenus;
        public string[] SubMenus { get; set; }

        public Menu(string title, string[] subMenus)
        {
            this.title = title;
            this.subMenus = subMenus;
        }
        
        public void ShowMenu()
        {
            Console.Clear();

            Console.WriteLine(this.title + "\n");

            int counter = 1;
            foreach (string subMenu in subMenus)
            {
                Console.WriteLine($"{counter}. {subMenu}");
                counter++;
            }

            Console.Write("\n\n(Tryk menupunkt eller 0 for at afslutte) ");
        }

        public int SelectSubMenu()
        {
            ShowMenu();

            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out int menuIdx))
                {
                    if (menuIdx == 0)
                        return -1;

                    else if (menuIdx > 0 && menuIdx < subMenus.Length)
                        return menuIdx -1;
                }

                else
                { Console.WriteLine("Du skal vælge et menupunkt mellem 0 og " + subMenus.Length); }
            }
        }

        void CostumerMenu()
        {

        }

        void WareHouseMenu()
        {

        }

        void Request()
        {

        }

    }

}
