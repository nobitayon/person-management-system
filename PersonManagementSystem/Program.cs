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

        class Manager
        {
            public List<Person> people;

            public Manager()
            {
                people = new List<Person>()
                {
                    new Person("totti",42),
                    new Person("mario",33),
                    new Person("de rossi",45),

                };
                printMenu();
            }

            public void printMenu()
            {
                Console.WriteLine("Welcome to my management system" + Environment.NewLine);
                Console.WriteLine("1. Print all users");
                Console.WriteLine("2. Add user");
                Console.WriteLine("3. Edit user");
                Console.WriteLine("4. Search user");
                Console.WriteLine("5. Remove user");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your menu option: ");

                if (int.TryParse(Console.ReadLine(), out int menuOption))
                {
                    // converted successfully
                    Console.WriteLine(menuOption);

                    if (menuOption == 1)
                    {
                        PrintAll();
                    }else if(menuOption == 2)
                    {
                        AddPerson();
                    }
                    else if (menuOption == 3)
                    {
                        EditPerson();
                    }
                    else if (menuOption == 4)
                    {
                        SearchPerson();
                    }
                    else if (menuOption == 5)
                    {
                        RemovePerson();
                    }

                    printMenu();
                }
                else
                {
                    // failed
                    Console.WriteLine("Incorrect menu choice.");
                    Console.WriteLine("Press <Enter> to try again.");
                    Console.ReadLine();
                    Console.Clear();
                    printMenu();
                }
            }

            public void PrintAll()
            {
                Console.Clear();

                Console.WriteLine("Printing all users:" + Environment.NewLine);

                // print all element of people

                for (int i = 0; i < people.Count; i++) { 
                    Console.WriteLine(i+1+". " + people[i].returnDetails());
                }

                Console.WriteLine("You have finished this option. Press <Enter> to return to the menu.");
                Console.ReadLine();
                Console.Clear();


                // another alternative
                // 1. delegate
                //int i = 0;
                //people.ForEach(delegate (Person person) 
                //{
                //    i++; 
                //    Console.WriteLine(i+". "+person.returnDetails());
                //});

                // 2.arrow function
                //people.ForEach(person =>
                //{
                //    i++;
                //    Console.WriteLine(person.returnDetails());
                //});

                // 3.Usual ForEach
                //foreach (Person person in people)
                //{
                //    i++;
                //    Console.WriteLine(i + ". " + person.returnDetails());
                //}
            }

            public void AddPerson()
            {
                Console.WriteLine("add");
            }

            public void EditPerson()
            {
                Console.WriteLine("edit");
            }

            public void SearchPerson()
            {
                Console.WriteLine("search");
            }

            public void RemovePerson()
            {
                Console.WriteLine("remove");
            }
        }

        static void Main(string[] args)
        {
            //Person person = new Person("Ab",23);

            //Console.WriteLine(person.returnDetails());  

            //person.setName("yon");
            //person.setAge(24);   

            //Console.WriteLine(person.returnDetails()); 

            Manager manager = new Manager();


            Console.ReadLine();  
        }
    }
}