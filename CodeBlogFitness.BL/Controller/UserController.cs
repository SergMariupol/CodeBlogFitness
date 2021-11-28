using System;


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
            using (var fs = new FileStream("Users.dat", filemode.OpenOrCreate))
            {
                formatter.serialize(fs, User);
            }
        }
        /// <summary>
        /// получить данные пользователя
        /// </summary>
        /// <returns>пользователь приложения</returns>
       public User Load()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("Users.dat", filemode.OpenOrCreate))
            {               
               return formatter.deserialize(fs) as User;           
            }
        }

    }
}
