using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class CarPassport
    {
       public Driver Owner { set; get; }

       public readonly Car Car;

       public CarPassport(Car car)
       {
            Car = car;
       }
    }
}
