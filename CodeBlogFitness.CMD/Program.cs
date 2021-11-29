using CodeBlogFitness.BL.Controller;
using System;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение CodeBlogFitness");
            Console.WriteLine("Введите имя пользователя");

            var name = Console.ReadLine();

            var usercontroller = new UserController(name);
            if (usercontroller.IsNewUser)
            {



                Console.WriteLine("Введите пол");
                //  var gender =   Console.ReadLine();
                var gender = new BL.Model.Gender(Console.ReadLine());

                var birthDate = ParseDateTime();
                var weight = ParseDouble("Вес");
                var height = ParseDouble("Рост");

                usercontroller.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(usercontroller.CurrentUser);
            Console.ReadLine();
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введите дату дня рождения");

                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Не коректная дата рождения");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
            {
                while (true)
                {
                    Console.WriteLine($"Введите {name}:");

                    if (double.TryParse(Console.ReadLine(), out double value))
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine($"Не верный формат {name}");
                    }
                }
            }
        
    }
}
