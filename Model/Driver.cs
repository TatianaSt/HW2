using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Driver
    {
        public readonly DateTime LicenceDate;

        public int Experience
        {
            get
            {
                return (Convert.ToInt32(DateTime.Now - LicenceDate))/365;
            }
        }

        public readonly string Name;

        public List<string> Categories = new List<string>();

        public Car Car { get; internal set; }

        public Driver(DateTime licDate, string name)
        {
            LicenceDate = licDate;
            Name = name;
        }

        public void OwnCar(Car newCar)
        {
            if (Categories.Count != 0)
            {
                if (Categories.Contains(newCar.Category))
                {
                    Car = newCar;
                    Car.CarPassport.Owner = this;
                }
                else throw new Exception(string.Format("Driver {0} has not category {1}", Name, newCar.Category));
            }
            else
            {
                Console.WriteLine("The driver hasn't any categories");
            }

        }
        }

    }

