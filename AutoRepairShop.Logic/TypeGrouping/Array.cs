using Microsoft.VisualBasic;
using System.Threading.Channels;

namespace AutoRepairShop.Logic.TypeGrouping
{
    public class ArrayTests
    {
        //public string[] Bilmærker { get; set; }


        // 2D Array
        string[,] bilmærker2D = new string[2, 3]
        {
            {"Toyota", "Mazda", "Nissan"},
            {"Audi", "BMV", "Mercedes"}
        };

        // 3D Array
        string[,,] bilmærker3D = new string[1, 2, 3]
        {
            {
                {"Toyota","Mazda","Nissan", },
                { "Audi", "BMV", "Mercedes" }
            }
        };

        // Jagged Array
        string[][] bilmærkerJagged = new string[][]
        {
            new string[]{"Toyota", "Mazda", "Nissan", "Suzuki"},
            new string[]{"Audi", "BMV", "Mercedes"}
        };

        // object Array
        public void ObjSamling()
        {
            // object Array
            object[] objSamling = new object[]
            {
            "Hello",
            12,
            new DateTime(2020,12,31)
            };

            string strDato = $"Dato er: {(DateTime)objSamling[2]:dd/MM/yyyy}";
            Console.WriteLine(strDato);
        }
    }
}