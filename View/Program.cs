using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace View
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Автомобиль не найден. Необходимо добавить автомобиль");
            Console.WriteLine("Укажите модель автомобиля" + "\n");
            string model = Console.ReadLine();
            Console.WriteLine("Введите категорию данного ТС" + "\n");
            string category = Console.ReadLine().ToLower();
            var car = new Car(model, category);

            Console.WriteLine("У вас нет ни одного водителя. Наймите инструктора");
            Console.WriteLine("Введите имя водителя:" + "\n");
            string driverName = Console.ReadLine();
           
            Console.WriteLine("Укажите дату получения водительского удостоверения:" + "\n");
            DateTime driverLicDate;
            try
            {
                driverLicDate = Convert.ToDateTime(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Вы указали неверный формат даты, укажите корректную дату");
                driverLicDate = Convert.ToDateTime(Console.ReadLine());
            }

            var driver = new Driver(driverLicDate, driverName);
            bool exit = false;
            int mainMenu = 0;
            while (!exit)
            {
               Console.WriteLine("Выберите раздел: 1-Автомобили; 2 - Водители;" + "\n");
                mainMenu = Convert.ToInt32(Console.ReadLine());
                bool back = false;
                while (!back)
                {


                    switch (mainMenu)
                    {
                            #region CarMenu

                        case 1:
                            Console.WriteLine("1 - Задать цвет;" + "\n" +
                                              "2 - Информация о владельце;" 
                                               + "\n" +  "3 - Вернуться в предыдущее меню" + "\n");
                            int carMenu = Convert.ToInt32(Console.ReadLine());
                            switch (carMenu)
                            {
                                case 1:
                                    Console.WriteLine("Введите цвет" + "\n");
                                    car.Color = Color.FromName(name: Console.ReadLine());
                                    break;

                               
                                case 2:
                                    if (car.CarPassport.Owner != null)
                                    {
                                        Console.WriteLine(car.CarPassport.Owner.Name.ToString());
                                    }
                                    else
                                    {
                                        Console.WriteLine("Данному автомобилю не присвоен владелец");
                                    }
                                    break;

                               
                                case 3:
                                    back = true;
                                    break;
                            }
                            break;
                    #endregion

                    #region CarDriver

                    case 2:
                            Console.WriteLine("1 - Закрепить автомобиль за водителем;" + "\n" +
                                            "2 - Добавить категорию;" + "\n" + "3 - Информация о номере автомобиля;" +
                                            "\n"  + "4 - Поменять владельца"+ "\n"+"5 - Просмотр информации о владельце автомобиля" + "\n" + "6 - Вернуться в предыдущее меню" + "\n");
                            int driverMenu = int.Parse(Console.ReadLine());
                            switch (driverMenu)
                            {
                                case 1:
                                    Console.WriteLine("Закрепить автомобиль "+car.Model +" "+car.CarNumber+" за водителем "+driver.Name+"?");
                                    Console.WriteLine("1 - Да; 2 - Нет");
                                    int confirm = Int32.Parse(Console.ReadLine());
                                    if (confirm == 1)
                                    {
                                        driver.OwnCar(car);
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("Укажите категории:" + "\n");
                                    string[] categoriesArray = Console.ReadLine().ToLower().Split(new char[] { ' ', ',', '.', ';' });
                                    foreach (var c in categoriesArray)
                                    {
                                        driver.Categories.Add(c);
                                    }
                                    break;
                                case 3:
                                    if (car.CarNumber != null)
                                    {
                                        Console.WriteLine(car.CarNumber);
                                    }
                                    else
                                    {
                                        Console.WriteLine("У машины не указан номер");
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("Для выбора доступны водители: "+ driver.Name);
                                    Console.WriteLine("Впишите номер автомобиля");
                                    string carNumber = Console.ReadLine();
                                    Console.WriteLine("Впишите имя нового владельца");
                                    driverName = Console.ReadLine().ToLower();
                                    if (driverName == driver.Name.ToLower())
                                    {
                                        car.ChangeOwner(driver, carNumber);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Водителя с таким именем не существует");
                                    }
                                    break;
                                case 5:
                                    if (car.CarPassport.Owner != null)
                                    {
                                        Console.WriteLine("Владелец автомобиля " + car.Model + ":" +
                                                          car.CarPassport.Owner.Name);
                                    }
                                    else
                                    {
                                        Console.WriteLine("У данного автомобиля нет владельца");
                                    }
                                    break;

                                case 6:
                                    back = true;
                                    break;
                            }
                            break;

                    #endregion
                }
            }

        }
            
                Console.ReadKey();
            }



        
    }
}
