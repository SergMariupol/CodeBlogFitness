using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{/// <summary>
/// контроллер пользователя
/// </summary>
    public class UserController
    {/// <summary>
    /// пользователь приложения
    /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// создание нового пользователя
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {//проверка
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

 

            


            //var gender = new Gender(genderName);
           // Users = new User(userName, gender, birthDate, weight, height);
        }
        /// <summary>
        /// получить список пользователей
        /// </summary>
        /// <returns>пользователь приложения</returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("Users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                } 
                else
                {
                    return new List<User>();
                }
            }
            return null;
        }

        public void SetNewUserData(string genderName, DateTime bithDate, double weight=1, double height=1)
        {
            //проверка
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = bithDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();


        }
        /// <summary>
        /// сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("Users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }
       

    }
}
