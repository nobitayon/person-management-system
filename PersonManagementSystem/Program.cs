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
                people = new List<Person>(){};
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
                    OutputMessage("Incorrect menu choice.");
                    printMenu();
                }
            }

            public void PrintAll()
            {
                StartOption("Printing all users:");

                // print all element of people

                if (people.Count == 0)
                {
                    Console.WriteLine("There are no users in the system, use option 1 to create a user");
                }
                else
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        Console.WriteLine(i + 1 + ". " + people[i].returnDetails());
                    }
                }

                

                finishOption();


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
                StartOption("Adding a user:");

                // enter a name
                // enter an age
                // create a person class
                // add to the list
                // return to the menu

                try
                {
                    Console.Write("Enter a name: ");
                    string nameInput = Console.ReadLine();

                    Console.Write("Enter a age: ");
                    int ageInput = Convert.ToInt32(Console.ReadLine());

                    if (!string.IsNullOrEmpty(nameInput))
                    {
                        if(ageInput>=0 && ageInput <= 150)
                        {
                            Person person = new Person(nameInput, ageInput);
                            people.Add(person);
                            Console.WriteLine("Successfully added a person.");
                            finishOption();
                        }
                        else
                        {
                            OutputMessage("Enter a sensible age");
                            AddPerson();
                        }
                    }
                    else
                    {
                        OutputMessage("You didn't enter a name");
                        AddPerson();
                    }
                
                }
                catch (Exception) 
                {
                    OutputMessage("Something has went wrong. Press <Enter> to try again.");
                    AddPerson();
                }

                
            }

            public void EditPerson()
            {
                StartOption("Editing a user:");

                // check if people in the system
                // print all
                // allow selection
                // validate selection
                // edit user, print message
                // return back to the menu

                finishOption();
                finishOption();
            }

            public void SearchPerson()
            {
                StartOption("Searching a user:");
                finishOption();
            }

            public void RemovePerson()
            {
                StartOption("Removing a user:");
                finishOption();
            }

            public void finishOption()
            {
                Console.WriteLine(Environment.NewLine + "You have finished this option. Press <Enter> to return to the menu.");
                
                Console.ReadLine();
                Console.Clear();
            
            }

            public void StartOption(string message)
            {
                Console.Clear();
                Console.WriteLine(message + Environment.NewLine);
            }

            public void OutputMessage(string message) 
            {
                Console.WriteLine(message+" Press <Enter> to try again.");
                Console.ReadLine(); 
                Console.Clear();
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