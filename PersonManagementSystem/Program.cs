using System;
using System.Collections.Generic;

namespace PersonManagementSystem
{
    class Program
    {
        class Person 
        {
            public string name {get; protected set;}
            public int age {get; protected set;}

            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }

            public void setName(string name)
            {
                this.name = name;
            }

            public void setAge(int age)
            {
                this.age = age;
            }

            public string returnDetails()
            {
                return name + " - " + age;
            }
        }

        static void Main(string[] args)
        {
            Person person = new Person("Ab",23);

            Console.WriteLine(person.returnDetails());  

            person.setName("yon");
            person.setAge(24);   

            Console.WriteLine(person.returnDetails()); 

            Console.ReadLine();  
        }
    }
}