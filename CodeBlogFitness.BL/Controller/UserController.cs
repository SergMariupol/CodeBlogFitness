using CodeBlogFitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{/// <summary>
/// контроллер пользователя
/// </summary>
    public class UserController
    {/// <summary>
    /// пользователь приложения
    /// </summary>
        public User User { get; }
        /// <summary>
        /// создание нового пользователя
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
        {//проверка
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weight, height);
        }
        /// <summary>
        /// получить данные пользователя
        /// </summary>
        /// <returns>пользователь приложения</returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("Users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                //TODO: Что делать, если пользователь не прочитали
            }
        }
        /// <summary>
        /// сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("Users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
       

    }
}
