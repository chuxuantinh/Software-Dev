using System;
using System.Collections.Generic;
using System.Text;

namespace P06ValidPerson
{
    public class Student
    {
        private string name;


        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                foreach (var symbol in value)
                {
                    if (char.IsDigit(symbol))
                    {
                        throw new InvalidPersonNameException();
                    }
                }

                this.name = value;
            }
        }

        public string Email { get; set; }
    }
}
