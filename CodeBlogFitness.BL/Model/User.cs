using System;


namespace CodeBlogFitness.BL.Model
{/// <summary>
/// пользователь
/// </summary>
/// 
    [Serializable]
    public class User
    #region Свойства
    {/// <summary>
     /// имя
     /// </summary>
        public string Name { get; }
        /// <summary>
        /// пол
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// рост
        /// </summary>
        public double Height { get; set; }

        public int  Age 
        { get 
            { 
                return DateTime.Now.Year - BirthDate.Year; 
            } 
        }
        #endregion
        /// <summary>
        /// создать нового пользователя
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="gender">пол</param>
        /// <param name="birthdate">день рождение</param>
        /// <param name="weight">вес</param>
        /// <param name="height">рост</param>
        public User(string name,
                    Gender gender,
                    DateTime birthdate,
                    double weight,
                    double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть Null", nameof(gender));
            }
            if (birthdate < DateTime.Parse("01.01.1900") || birthdate > DateTime.Now)
            {
                throw new ArgumentNullException("Невозможная дата рождения", nameof(birthdate));
            }            
            if (weight <= 0)
            {
                throw new ArgumentNullException("Вес не может быть меньше либо равен 0", nameof(Weight));
            }
            if (height <= 0)
            {
                throw new ArgumentNullException("Рост не может быть меньше либо равен 0", nameof(Weight));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthdate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name + " " + Age;
        }


    }
}
