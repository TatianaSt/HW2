using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Model
{
    public class Car
    {
        public string Model;
        public Color Color { set; get; } = Color.Blue;
        public string CarNumber { internal set; get; }
        public readonly string Category;
        public readonly CarPassport CarPassport;

        public Car(string model, string category)
       {
           Model = model;
           Category = category;
           CarPassport = new CarPassport(this);
       }

        public void ChangeOwner(Driver newDriver, string newCarNumber)
        {
            if (newDriver != null && !string.IsNullOrEmpty(newCarNumber))
            {
                CarPassport.Owner = newDriver;
                CarNumber = newCarNumber;
                CarPassport.Owner.OwnCar(this);
            }
            else
            {
                Console.WriteLine("Driver or Car Number has empty value");
            }
        }
    }
}
