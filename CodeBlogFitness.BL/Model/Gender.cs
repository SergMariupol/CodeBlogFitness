using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// пол
    /// </summary>
    /// 
    [Serializable]
    public class Gender
    {/// <summary>
    /// название
    /// </summary>
        public string Name { get; }
        /// <summary>
        /// создать новый пол
        /// </summary>
        /// <param name="name"> имя пола</param>
        public Gender(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустыи или  Null", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }

        public static implicit operator string(Gender v)
        {
            throw new NotImplementedException();
        }
    }
}
