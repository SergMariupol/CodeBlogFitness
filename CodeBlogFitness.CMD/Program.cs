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



            /*
            Console.WriteLine("Введите пол");
            var gender = Console.ReadLine();
            Console.WriteLine("Введите дату дня рождения");
            var birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите вес");
            var weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите рост");
            var height = double.Parse(Console.ReadLine());
            */


            var usercontroller = new UserController(name);
            if(usercontroller.IsNewUser)
            {

            }
            Console.WriteLine(usercontroller.CurrentUser);
            Console.ReadLine();


        }
    }
}
