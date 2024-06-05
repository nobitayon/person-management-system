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
                people = new List<Person>(){
                    //new("totti",30),
                    //new("toni",33),
                    //new("gian",20)
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

                    if(menuOption>=1 && menuOption <= 5)
                    {
                        printMenu();
                    }

                    
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

                if (!isSystemEmpty())
                {
                    PrintAllUsers();
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
                    Person person = returnPerson();
                    if (person != null)
                    {
                        people.Add(person);
                        Console.WriteLine("Successfully added a person.");
                        finishOption();
                    }
                    else
                    {
                        OutputMessage("Something has went wrong.");
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

                if(!isSystemEmpty())
                {
                    PrintAllUsers();
                    try
                    {
                        Console.Write("Enter an index: ");
                        int indexSelection = Convert.ToInt32(Console.ReadLine());
                        indexSelection -= 1;

                        if (indexSelection>=0 && indexSelection <= people.Count - 1)
                        {

                            try
                            {
                                Person person = returnPerson();
                                if (person != null)
                                {
                                    people[indexSelection] = person;
                                    Console.WriteLine("Successfully edited a person.");
                                    finishOption();
                                }
                                else
                                {
                                    OutputMessage("Something has went wrong.");
                                    EditPerson();
                                }

                            }
                            catch (Exception)
                            {
                                OutputMessage("Something has went wrong. Press <Enter> to try again.");
                                EditPerson();
                            }
                        }
                        else
                        {
                            OutputMessage("Enter a valid index range.");
                            EditPerson();
                        }

                    }
                    catch(Exception) 
                    {
                        OutputMessage("Something went wrong.");
                        EditPerson();
                    }

                }
                else
                {
                    OutputMessage("");
                }

            }

            public void SearchPerson()
            {
                StartOption("Searching a user:");

                // check if people in system
                // get name input
                // validate name
                // loop and check for name
                // output results

                if(!isSystemEmpty())
                {
                    Console.Write("Enter a name: ");
                    string nameInput = Console.ReadLine();
                    bool bFound = false;
                    if (!string.IsNullOrEmpty(nameInput))
                    {
                        for(int i = 0; i < people.Count; i++)
                        {
                            if (people[i].name.ToLower().Contains(nameInput))
                            {
                                Console.WriteLine(people[i].returnDetails());
                                bFound = true;
                            }
                        }

                        if (!bFound)
                        {
                            Console.WriteLine("No user found with that name");
                        }
                      

                        finishOption();
                    }
                }
                else
                {
                    OutputMessage("");
                }
            }

            public void RemovePerson()
            {
                StartOption("Removing a user:");

                // check if people in system
                // output list of users
                // input selection
                // validation selection
                // print message
                // return back to the menu

                if(!isSystemEmpty())
                {
                    PrintAllUsers();
                    Console.Write("Enter an index: ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    index -= 1;

                    if(index>=0 && index <= people.Count - 1)
                    {
                        people.RemoveAt(index);
                        Console.WriteLine("Successfully removed a person");
                        finishOption();
                    }
                    else
                    {
                        OutputMessage("Enter a valid index inside the range.");
                        RemovePerson();
                    }
                }
                else
                {
                    OutputMessage("");
                }
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

                if (message == "")
                {
                    Console.Write("Press <Enter> to return to the menu");
                }
                else
                {
                    Console.WriteLine(message + " Press <Enter> to try again.");
                }
                
                
                Console.ReadLine(); 
                Console.Clear();
            }

            public void PrintAllUsers()
            {
                for (int i = 0; i < people.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + people[i].returnDetails());
                }
            }

            public Person returnPerson()
            {
                try
                {
                    Console.Write("Enter a name: ");
                    string nameInput = Console.ReadLine();

                    Console.Write("Enter a age: ");
                    int ageInput = Convert.ToInt32(Console.ReadLine());

                    if (!string.IsNullOrEmpty(nameInput))
                    {
                        if (ageInput >= 0 && ageInput <= 150)
                        {
                            return new Person(nameInput, ageInput);
                        }
                        else
                        {
                            OutputMessage("Enter a sensible age");
                        }
                    }
                    else
                    {
                        OutputMessage("You didn't enter a name");
                    }

                }
                catch (Exception)
                {
                    OutputMessage("Something has went wrong. Press <Enter> to try again.");
                }
                return null;
            }

            public bool isSystemEmpty()
            {
                if(people.Count == 0)
                {
                    Console.WriteLine("There are no users in the system.");
                    return true;
                }
                else
                {
                    return false;
                }

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

            Console.WriteLine("Goodbye!");
            Console.ReadLine();  
        }
    }
}