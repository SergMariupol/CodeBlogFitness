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
        public UserController(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть равен Null"nameof(user));
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
        /// <summary>
        /// получить данные пользователя
        /// </summary>
        /// <returns>пользователь приложения</returns>
       public User Load()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("Users.dat", FileMode.OpenOrCreate))
            {               
               return formatter.Deserialize(fs) as User;           
            }
        }

    }
}
