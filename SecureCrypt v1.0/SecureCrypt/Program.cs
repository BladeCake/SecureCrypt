using System;
using System.Linq;
using System.Collections.Generic;
using SecureCrypt;
using System.IO;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;

namespace ABC_Systems_Assignment_1 ////////////////////// TO DO ==> Make the '`' key not be able to be entered for any attribute.
                                   //////////////////////        => Fix delete entry when app exits during edit.
                                   //////////////////////        => There was more but I forgot.
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 40);
           

            Crypt crypt = new Crypt();
            Headings heading = new Headings();

            bool bBusy = true;

            while (bBusy ==true) //Deals with creation of an account, logging in, and displaying the home page
            {
                if (!File.Exists("user.txt")) //If the txt file does not exist, it is a new user
                {

                    bool bCheck = false;

                    while (bCheck == false) //Ensures user enters in information
                    {
                        //displayHeading(heading.SecureCrypt());
                        displaySubHeading(heading.Register());
                        //Console.WriteLine("Please ensure your credentials are correct.");
                        displayText("Please ensure your credentials are correct.", heading.Register());
                        space();
                        space();

                        //Console.Write("Username ==> ");
                        displayText("Username ==> ", heading.Register());
                        string userName = Console.ReadLine();
                        space();

                        //Console.Write("Password ==> ");
                        displayText("Password ==> ", heading.Register());
                        string userPassword = Console.ReadLine();
                        space();

                        if(userName == "" || userPassword == "") //INVALID CHOICE
                        {
                            Console.Clear();

                            //displayHeading(heading.SecureCrypt());
                            displaySubHeading(heading.InvalidChoice());
                            //Console.WriteLine("Please do not leave any fields empty.");
                            displayText("Please do not leave any fields empty.", heading.InvalidChoice());
                            space();
                            space();
                            //Console.Write("Press 'ENTER' to continue... ");
                            displayText("Press 'ENTER' to continue... ", heading.InvalidChoice());
                            Console.ReadLine();

                            Console.Clear();
                        }
                        else //WRITE TO FILE
                        {
                            string creds = crypt.encrypt(userName) + "$" + crypt.encrypt(userPassword);

                            StreamWriter sw = new StreamWriter("user.txt");
                            sw.WriteLine(creds);
                            sw.Close();
                            bCheck = true;
                        }
                        
                        if(bCheck == true) //SUCCESS PAGE
                        {
                            Console.Clear();

                            displaySubHeading(heading.Success());

                            //Console.WriteLine("User has been successfully created.");
                            displayText("User has been successfully created.", heading.Success());
                            space();
                            space();

                            //Console.Write("Press 'ENTER' to continue to login...");
                            displayText("Press 'ENTER' to continue to login...", heading.Success());
                            Console.ReadLine();
                        }
                    }
                    
                }
                else //===================== LOGIN PAGE =====================//
                {
                    bool bCheck = false;

                    while(bCheck == false)
                    {
                        Console.Clear();

                        //displayHeading(heading.SecureCrypt());  <====  //TO DO: remember register page
                        displaySubHeading(heading.Login());

                        //Console.WriteLine("Please enter in your password.");
                        displayText("Please enter in your password.", heading.Login());
                        space();

                        //Console.Write("# ==> ");
                        displayText("# ==> ", heading.Login());
                        string loginPass = Console.ReadLine();

                        if(loginPass == "")//EMPTY LOGIN
                        {
                            Console.Clear();

                            displaySubHeading(heading.InvalidChoice());
                            //Console.WriteLine("Please do not leave any fields empty.");
                            displayText("Please do not leave any fields empty.", heading.InvalidChoice());
                            space();
                            space();
                            //Console.Write("Press 'ENTER' to continue... ");
                            displayText("Press 'ENTER' to continue... ", heading.InvalidChoice());
                            Console.ReadLine();

                            Console.Clear();
                        }
                        else
                        {
                            StreamReader sr = new StreamReader("user.txt");
                            bool passwordMatch = false;

                            while (sr.EndOfStream == false)//not at the end of txt file
                            {
                                string entry = sr.ReadLine();

                                string[] details = entry.Split('$');

                                string storedPassword = crypt.decrypt(details[1]);

                                if(storedPassword == loginPass)
                                {
                                    passwordMatch = true;
                                    break;
                                }

                            }

                            if (passwordMatch == false) //PASSWORD NOT FOUND
                            {
                                Console.Clear();

                                displaySubHeading(heading.InvalidChoice());
                                //Console.WriteLine("Invalid password, try again.");
                                displayText("Invalid password, try again.", heading.InvalidChoice());
                                space();
                                space();
                                //Console.Write("Press 'ENTER' to continue... ");
                                displayText("Press 'ENTER' to continue... ", heading.InvalidChoice());
                                Console.ReadLine();

                                Console.Clear();
                            }
                            else bCheck = true; //PASSWORD MATCH


                            sr.Close();

                        }


                    }

                    Console.Clear();

                     //===================== HOME PAGE =====================//
                    
                    bool bFinished = false;

                    string[] homeOptions = { "Options:", "Search for an entry", "List all stored entries", "Add a new entry", "Exit" };

                    while (bFinished == false)
                    {
                        int choice = -1;


                        choice = displayOptions(homeOptions, heading.Welcome()); //display the list of options

                        if (choice == 4)
                        {
                            Console.Clear();

                            displaySubHeading(heading.Exiting());

                            //Console.WriteLine("Exiting SecureCrypt");
                            displayText("Exiting SecureCrypt", heading.Exiting());
                            space();
                            space();
                            //Console.Write("Press 'ENTER' to continue... ");
                            displayText("Press 'ENTER' to continue... ", heading.Exiting());
                            Console.ReadLine();

                            Console.Clear();

                            Environment.Exit(0);
                            
                        }
                        else if (choice == 3)
                        {
                            addNewEntry("add", "", "");
                        }
                        else if (choice == 2)
                        {
                            listAllEntries();
                        }
                        else
                        {
                            searchForEntry();
                        }

                    }//===========================================================================================//
                }
            }//END OF BIG WHILE
        }//END OF MAIN

        static void space()
        {
            Console.WriteLine();
        }

        static void searchForEntry()//==================================================== SEARCH ENTRIES ====================================================//
        {
            Crypt crypt = new Crypt();
            Headings heading = new Headings();

            if (!File.Exists("crypt.txt"))//IF THE FILE DOES NOT EXIST
            {
                Console.Clear();
                displaySubHeading(heading.InvalidChoice());

                //Console.WriteLine("You have not added any entries yet.");
                displayText("You have not added any entries yet.", heading.InvalidChoice());
                space();

                //Console.Write("Press 'ENTER' to continue... ");
                displayText("Press 'ENTER' to continue... ", heading.InvalidChoice());
                Console.ReadLine();

                Console.Clear();
            }
            else
            {
                bool bCheck = false;
                while (bCheck == false)
                {
                    List<string> encryptedEntries = new List<string>();
                    List<string> decryptedEntries = new List<string>();
                    List<string> indexTracker = new List<string>();
                    string[] indexArr = new string[2];

                    StreamReader sr = new StreamReader("crypt.txt");

                    int count = 0;
                    while (sr.EndOfStream == false)
                    {
                        encryptedEntries.Add(sr.ReadLine());
                        count++;
                    }

                    sr.Close();

                    int iCount = 0;
                    for (int k = 0; k < count; k++)//DECRYPT ENTRIES AND STORE THEM IN A LIST
                    {

                        string[] entry = encryptedEntries.ElementAt(k).Split('$');

                        decryptedEntries.Add(crypt.decrypt(entry[0]) + "`" + crypt.decrypt(entry[1]));
                        indexTracker.Add(crypt.decrypt(entry[0]) + "-" + iCount);
                        iCount++;
                    }

                    Console.Clear();

                    displaySubHeading(heading.Search());

                    //Console.WriteLine("Please enter a search term below. Leave blank to go back to the main menu.");
                    displayText("Please enter a search term below. Leave blank to go back to the main menu.", heading.Search());
                    space();
                    space();
                    //Console.WriteLine("Note: this search function is case sensitive.");
                    displayText("Note - the search function is case sensitive.", heading.Search());
                    space();


                    //Console.Write("Search: ");
                    displayText("Search: ", heading.Search());
                    string searchTerm = Console.ReadLine();

                    List<string> searchedList = new List<string>();
                    List<string> searchedIndexTracker = new List<string>();

                    if (searchTerm != "")
                    {
                        searchedList = decryptedEntries.Where(e => e.Contains(searchTerm)).ToList();
                        searchedIndexTracker = indexTracker.Where(e => e.Contains(searchTerm)).ToList();

                        if (searchedList.Count() == 0)
                        {
                            Console.Clear();

                            displaySubHeading(heading.InvalidChoice());
                            //Console.WriteLine("Could not find a match for the term '" + searchTerm + "'");
                            displayText("Could not find a match for the term '" + searchTerm + "'", heading.InvalidChoice());
                            space();
                            space();
                            //Console.Write("Press 'ENTER' to continue... ");
                            displayText("Press 'ENTER' to continue... ", heading.InvalidChoice());
                            Console.ReadLine();
                        }
                        else
                        {
                            searchedList.Sort();
                            searchedIndexTracker.Sort();

                            string[] arrSearchedList = new string[searchedList.Count() + 2];

                            arrSearchedList[0] = "The following entries were found.";

                            int icount = 0;
                            for (int k = 0; k < searchedList.Count(); k++)
                            {
                                string[] item = searchedList[k].Split("`");
                                arrSearchedList[k + 1] = item[0];
                                icount++;
                            }

                            Console.Clear();
                            arrSearchedList[icount + 1] = "Back";

                            int choice = displayOptions(arrSearchedList, heading.Entries());

                            if(choice != icount+1)
                            {
                                displaySingleEntryInfo(searchedList, indexArr, searchedIndexTracker, choice);
                            }
                        }
                    }
                    else
                    {
                        bCheck = true;
                        Console.Clear();
                        //listAllEntries();
                    }
                }
            }
        }//============================================================================================================================//

        static void listAllEntries() //==================================================== LISTING ENTRIES ====================================================//
        {
            Crypt crypt = new Crypt();
            Headings heading = new Headings();

            if (!File.Exists("crypt.txt"))//IF THE FILE DOES NOT EXIST
            {
                Console.Clear();
                displaySubHeading(heading.InvalidChoice());

                //Console.WriteLine("You have not added any entries yet.");
                displayText("You have not added any entries yet.", heading.InvalidChoice());
                space();
                space();

                //Console.Write("Press 'ENTER' to continue... ");
                displayText("Press 'ENTER' to continue... ", heading.InvalidChoice());
                Console.ReadLine();

                Console.Clear();
            }
            else
            {
                Console.Clear();

                bool bCheck = false;

                

                while (bCheck == false)
                {

                    List<string> encryptedEntries = new List<string>();
                    List<string> decryptedEntries = new List<string>();
                    List<string> indexTracker = new List<string>();
                    string[] indexArr = new string[2];

                    int count = 0;
                    StreamReader sr = new StreamReader("crypt.txt");

                    while (sr.EndOfStream == false)//RECEIVE ALL ENCRYPTED ENTRIES
                    {

                        encryptedEntries.Add(sr.ReadLine());

                        count++;
                    }

                    sr.Close();

                    int iCount = 0;
                    for (int k = 0; k < count; k++)//DECRYPT ENTRIES AND STORE THEM IN A LIST
                    {

                        string[] entry = encryptedEntries.ElementAt(k).Split('$');

                        decryptedEntries.Add(crypt.decrypt(entry[0]) + "`"  + crypt.decrypt(entry[1]));
                        indexTracker.Add(crypt.decrypt(entry[0]) + "-" + iCount);
                        iCount++;
                    }


                    decryptedEntries.Sort();//SORT THE ENTRIES
                    indexTracker.Sort();//Sort index tracker


                    string[] items = new string[count + 2];//CREATE AN ARRAY THE SIZE OF THE LIST AND ADD 2 SPACES FOR THE HEADING AND BACK OPTION


                    iCount = 0; //USED TO KEEP TRACK OF SIZE OF ARRAY, SO THAT WE CAN ADD THE BACK OPTION AT THE END
                    items[0] = ("Enter in an index number to see more information."); //ADD THE HEADING

                    //displayText("The names and corresponding passwords are listed below.", heading.List());

                    for (int i = 0; i < decryptedEntries.Count; i++)
                    {
                        string[] singleEntry = (decryptedEntries.ElementAt(i)).Split('`');//SPLIT EACH ENTRY UP

                        items[i + 1] = (singleEntry[0]); //ADD IT TO THE ARRAY
                        iCount++;
                    }

                    iCount++;
                    items[iCount] = "Back to main menu.";//ADDS THE BACK OPTION

                    int choice = displayOptions(items, heading.List());


                    if (choice != iCount)//IF THE USER DID NOT SELECT THE BACK OPTION
                    {
                        displaySingleEntryInfo(decryptedEntries, indexArr, indexTracker, choice);
                    }
                    else
                    {
                        bCheck = true;
                    }

                    Console.Clear();
                }   

            }
        }//============================================================================================================================//

        static void displaySingleEntryInfo(List<string> decryptedEntries, string[] indexArr, List<string> indexTracker, int choice)
        {
            Headings heading = new Headings();
            Crypt crypt = new Crypt();

            Console.Clear();

            string[] singleEntry = (decryptedEntries.ElementAt(choice - 1)).Split('`');//SPLIT EACH ENCRYPTED ENTRY UP

            string[] options = {"Entry name: \t" + singleEntry[0] + "\n".PadRight(40) + "Password  : \t" + singleEntry[1] +"\n\n".PadRight(40) + " What would you like to do?",
                                        "Copy password", "Edit entry", "Delete Entry", "Back" };

            int choiceTwo = displayOptions(options, heading.Info());

            if (choiceTwo == 4)//Go back
            {
                //DO NOTHING, LET THE USER BE TAKEN BACK TO THE LIST PAGE
            }
            else if (choiceTwo == 3)//Delete Entry
            {
                string[] deleteOptions = { "Are you sure you want to delete the '" + singleEntry[0] + "' entry?", "Yes", "No" };

                Console.Clear();

                int deleteChoice = displayOptions(deleteOptions, heading.Delete());

                if (deleteChoice == 1)
                {
                    indexArr = (indexTracker.ElementAt(choice - 1)).Split('-');
                    deleteEntry(indexArr[1]);

                    Console.Clear();

                    displaySubHeading(heading.Success());

                    //Console.WriteLine("Entry '" + singleEntry[0] + "' has been successfully deleted.");
                    displayText("Entry '" + singleEntry[0] + "' has been successfully deleted.", heading.Success());
                    space();
                    space();

                    //Console.Write("Press 'ENTER' to continue...");
                    displayText("Press 'ENTER' to continue...", heading.Success());
                    Console.ReadLine();
                }

            }
            else if (choiceTwo == 2)//Edit Entry
            {
                indexArr = (indexTracker.ElementAt(choice - 1)).Split('-');
                deleteEntry(indexArr[1]);// EDIT FIRST DELETES ENTRY 

                addNewEntry("edit", singleEntry[0], singleEntry[1]);//THEN ADDS IT
            }
            else //Copy Password
            {
                Clipboard.SetText(singleEntry[1]);

                Console.Clear();

                displaySubHeading(heading.Copied());

                //Console.WriteLine("Successfully copied password to clipboard.");
                displayText("Password copied to clipboard.", heading.Copied());
                space();
                space();

                //Console.Write("Press 'ENTER' to continue...");
                displayText("Press 'ENTER' to continue...", heading.Copied());
                Console.ReadLine();
            }
        }

        static void deleteEntry(string index)//==================================================== DELETE ENTRY ====================================================//
        {
            List<string> allEntries = new List<string>();

            StreamReader sr = new StreamReader("crypt.txt");

            while (sr.EndOfStream == false)//RECEIVE ALL ENCRYPTED ENTRIES
            {
                allEntries.Add(sr.ReadLine());
            }

            sr.Close();

            allEntries.RemoveAt(int.Parse(index));

            StreamWriter sw = new StreamWriter("crypt.txt");

            for (int i = 0; i < allEntries.Count(); i++)
            {
                sw.WriteLine(allEntries[i]);
            }

            sw.Close();

        }//============================================================================================================================//

        static void addNewEntry(string editOrAdd, string name, string password)//==================================================== ADDING A NEW ENTRY ====================================================//
        {
            Crypt crypt = new Crypt();
            Headings heading = new Headings();
            string entryName = "";
            string entryPassword = "";
            bool bCheck = false;

            while (bCheck == false)
            {
                Console.Clear();

                if(editOrAdd == "add")//ADD
                {
                    displaySubHeading(heading.Add());

                    //Console.WriteLine("Please enter the required details to " + editOrAdd + " an entry.");
                    //displayText("Please enter the required details to " + editOrAdd + " an entry.", heading.Add());
                    //space();
                    //space();

                    //Console.Write("Entry Name: ");
                    displayText("Entry Name: ", heading.Add());
                    entryName = Console.ReadLine();

                    space();

                    //Console.Write("Entry Password: ");
                    displayText("Entry Password: ", heading.Add());
                    entryPassword = Console.ReadLine();

                    bool bNotDuplicate = true;
                    if (File.Exists("crypt.txt")) //CHECKING IF AN ENTRY WITH THE SAME NAME EXISTS
                    {
                        StreamReader sr = new StreamReader("crypt.txt");
                        string line;
                        string[] entry = new string[2];

                        while (sr.EndOfStream == false)//RECEIVE ALL ENCRYPTED ENTRIES
                        {
                            line = sr.ReadLine();
                            entry = line.Split('$');

                            if (crypt.decrypt(entry[0]) == entryName) //IF A MATCH WAS FOUND
                                bNotDuplicate = false;
                        }
                        sr.Close();
                    }

                    if (bNotDuplicate == true) //IF THE NAME IS UNIQUE
                    {
                        bool bValidName = true;
                        for (int i = 0; i < entryName.Length; i++)
                        {
                            if (entryName[i] == '$')//CHECKING IF THE '$' SYMBOL HAS BEEN ENTERED IN THE NAME FIELD
                                bValidName = false;
                        }

                        if (bValidName == false)//IF '$' IS IN THE NAME
                        {
                            Console.Clear();

                            displaySubHeading(heading.InvalidChoice());
                            //Console.WriteLine("The '$' character cannot be entered into the name field.");
                            displayText("The '$' character cannot be entered into the name field.", heading.InvalidChoice());
                            space();
                            space();
                            //Console.Write("Press 'ENTER' to continue... ");
                            displayText("Press 'ENTER' to continue... ", heading.InvalidChoice());
                            Console.ReadLine();
                        }
                        else
                        {
                            if (entryName == "" || entryPassword == "")//Any entered value is null
                            {
                                Console.Clear();

                                displaySubHeading(heading.InvalidChoice());
                                //Console.WriteLine("Please do not leave any fields empty.");
                                displayText("Please do not leave any fields empty.", heading.InvalidChoice());
                                space();
                                space();

                                displayText("Press 'ENTER' to continue... ", heading.InvalidChoice());
                                //Console.Write("Press 'ENTER' to continue... ");
                                Console.ReadLine();
                            }
                            else
                            {
                                string entry = crypt.encrypt(entryName) + "$" + crypt.encrypt(entryPassword);

                                StreamWriter sw = new StreamWriter("crypt.txt", true); //Append the new entry, or create the text file and add the new entry
                                sw.WriteLine(entry);
                                sw.Close();
                                bCheck = true;
                            }
                        }
                    }
                    else//IF THERE IS A NAME THAT EXISTS ALREADY
                    {
                        Console.Clear();

                        displaySubHeading(heading.InvalidChoice());
                        //Console.WriteLine("An entry with the same name already exists.");
                        displayText("An entry with the same name already exists.", heading.InvalidChoice());
                        space();
                        space();
                        //Console.Write("Press 'ENTER' to continue... ");
                        displayText("Press 'ENTER' to continue... ", heading.InvalidChoice());
                        Console.ReadLine();
                    }

                    
                }
                else //EDIT
                {
                    displaySubHeading(heading.Edit());

                    //Console.WriteLine("Please enter the required details to " + editOrAdd + " an entry.");
                    displayText("Please enter the required details to " + editOrAdd + " an entry.", heading.Edit());
                    space();
                    space();
                    Console.ForegroundColor = ConsoleColor.Red;
                    displayText("! WARNING - DO NOT EXIT BEFORE COMPLETION !", heading.Edit());
                    Console.ForegroundColor = ConsoleColor.White;
                    space();
                    space();

                    //Console.WriteLine("Current Details: ");
                    displayText("Current Details ", heading.Edit());
                    space();

                    //Console.WriteLine("Entry name: \t" + name + "\nPassword  : \t" + password);
                    displayText("Entry name: \t" + name, heading.Edit());
                    space();
                    displayText("Password  : \t" + password, heading.Edit());
                    space();
                    space();

                    //Console.WriteLine("Leave field blank to use current information.");
                    displayText("Leave field blank to use current information.", heading.Edit());
                    space();
                    space();

                    //Console.Write("New Name: ");
                    displayText("New Name: ", heading.Edit());
                    entryName = Console.ReadLine();

                    //Console.Write("New Password: ");
                    displayText("New Password: ", heading.Edit());
                    entryPassword = Console.ReadLine();

                    bool bNotDuplicate = true;
                    if (File.Exists("crypt.txt")) //CHECKING IF AN ENTRY WITH THE SAME NAME EXISTS
                    {
                        StreamReader sr = new StreamReader("crypt.txt");
                        string line;
                        string[] entry = new string[2];

                        while (sr.EndOfStream == false)//RECEIVE ALL ENCRYPTED ENTRIES
                        {
                            line = sr.ReadLine();
                            entry = line.Split('$');

                            if (crypt.decrypt(entry[0]) == entryName) //IF A MATCH WAS FOUND
                                bNotDuplicate = false;
                        }
                        sr.Close();
                    }

                    if (bNotDuplicate == true) //IF THE NAME IS UNIQUE
                    {
                        bool bValidName = true;
                        for (int i = 0; i < entryName.Length; i++)
                        {
                            if (entryName[i] == '$')//CHECKING IF THE '$' SYMBOL HAS BEEN ENTERED IN THE NAME FIELD
                                bValidName = false;
                        }

                        if (bValidName == false)//IF '$' IS IN THE NAME
                        {
                            Console.Clear();

                            displaySubHeading(heading.InvalidChoice());
                            //Console.WriteLine("The '$' character cannot be entered into the name field.");
                            displayText("The '$' character cannot be entered into the name field.", heading.InvalidChoice());
                            space();
                            space();
                            //Console.Write("Press 'ENTER' to continue... ");
                            displayText("Press 'ENTER' to continue... ", heading.InvalidChoice());
                            Console.ReadLine();
                        }
                        else
                        {

                            if (entryName == "")
                            {
                                entryName = name;
                            }

                            if (entryPassword == "")
                            {
                                entryPassword = password;
                            }


                            string entry = crypt.encrypt(entryName) + "$" + crypt.encrypt(entryPassword); //Append the new entry, or create the text file and add the new entry

                            StreamWriter sw = new StreamWriter("crypt.txt", true);
                            sw.WriteLine(entry);
                            sw.Close();
                            bCheck = true;
                        }
                    }
                    else//IF THERE IS A NAME THAT EXISTS ALREADY
                    {
                        Console.Clear();

                        displaySubHeading(heading.InvalidChoice());
                        //Console.WriteLine("An entry with the same name already exists.");
                        displayText("An entry with the same name already exists.", heading.InvalidChoice());
                        space();
                        space();
                        //Console.Write("Press 'ENTER' to continue... ");
                        displayText("Press 'ENTER' to continue... ", heading.InvalidChoice());
                        Console.ReadLine();
                    }
                }
               
            }
            //SUCCESSFULLY ADDED ENTRY
            Console.Clear();

            displaySubHeading(heading.Success());

            if (editOrAdd == "add")
            {
                //Console.WriteLine("Entry has been successfully added.");
                displayText("Entry has been successfully added.", heading.Success());
                space();
            }
            else
            {
                displayText("Entry has been successfully edited.", heading.Success());
                space();
            }
            
            space();

            //Console.Write("Press 'ENTER' to continue...");
            displayText("Press 'ENTER' to continue...", heading.Success());
            Console.ReadLine();
            Console.Clear();
        }//============================================================================================================================//

        static int displayOptions(string[] options, string[] subHead) //==================================================== DISPLAYING OPTIONS ====================================================//
        {
            Headings heading = new Headings();

            bool bCheck = false;
            string chosenOptionString = ""; //USED TO CHECK IF USER TYPED IN A STRING
            int chosenOption = -1; //WHAT WILL BE PASSED BACK

            while (bCheck == false)
            {
                displaySubHeading(subHead); //DISPLAY HEADINGS
                //displayUser();

                //Console.WriteLine(options[0]);
                displayText(options[0], subHead);//DISPLAY 3rd HEADING
                space();

                int index = 1;
                int elementBeingDisplayed = 0;//KEEP TRACK OF WHICH ELEMENT IS BEING DISPLAYED
                foreach (string option in options)//Displaying options to user
                {
                    if(elementBeingDisplayed != 0)//IF THE HEADING IS NOT BEING DISPLAYED, DISPLAY THE OPTIONS
                    {
                        displayText(index.ToString() + " ==> " + option, subHead);
                        space();
                        //Console.WriteLine(index.ToString() + " ==> " + option);
                        index++;
                    }

                    elementBeingDisplayed++;
                }

                space();

                //Console.WriteLine("Please enter a number between 1 and {0}", (index - 1).ToString());
                displayText("Please enter a number between 1 and " + (index - 1).ToString(), subHead);
                space();
                //Console.Write("# ==> ");
                displayText("# ==> ", subHead);

                chosenOptionString = Console.ReadLine(); //Receiving string input
                bool isNum = int.TryParse(chosenOptionString, out chosenOption); //Checking if user input can be converted to string 


                if ((isNum == true) && (chosenOption >= 1 && chosenOption < index))//If the user typed in an INTEGER and is between requirements
                {
                    return chosenOption;
                }
                else
                {
                    Console.Clear();

                    displaySubHeading(heading.InvalidChoice());

                    displayText("Please pick an option between 1 and " + (index - 1).ToString(), heading.InvalidChoice());
                    space();
                    space();
                    //Console.WriteLine("Please pick an option between 1 and {0}", (index - 1).ToString());
                    displayText("Press 'ENTER' to try again...", heading.InvalidChoice());
                    //Console.WriteLine("Press 'ENTER' to try again.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            return chosenOption;
        }

        public static void displayHeading(string[] heading)
        {
            int totalScreenSpace = 118;
            int numElements = heading[0].Length;
            int numSpaces = (totalScreenSpace - numElements) / 2;
            float lineLength;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            foreach (string line in heading)
            {
                for (int i = 0; i < numSpaces; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(line);
            }

            //foreach (string line in heading)
            //{
            //    Console.WriteLine(line);
            //}

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            //lineLength = heading[0].Length / 2;

            //for (int i = 0; i <= Math.Truncate(lineLength); i++)
            //{
            //    Console.Write("++");
            //}

            
            Console.ForegroundColor = ConsoleColor.White;

            
        }

        public static void displayUser()
        {
            Headings h = new Headings();
            string[] heading = h.User();
            int totalScreenSpace = 118;
            int numElements = heading[0].Length;
            int numSpaces = (totalScreenSpace - numElements) / 2;
            float lineLength;
            int SleepTimerTiny = 1;
            int SleepTimerSmall = 5;
            int sleepTimerBig = 10;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            foreach (string line in heading)
            {
                for (int i = 0; i < numSpaces; i++)
                {
                    Console.Write(" ");
                }
                System.Threading.Thread.Sleep(sleepTimerBig);
                Console.WriteLine(line);
            }


            Console.ForegroundColor = ConsoleColor.DarkYellow;

            lineLength = heading[0].Length / 2;

            for (int k = 0; k < numSpaces; k++)
            {
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (int i = 0; i <= Math.Truncate(lineLength); i++)
            {

                Console.Write("=-");
                System.Threading.Thread.Sleep(SleepTimerTiny);
            }

            Console.WriteLine("v1.0");


            Console.ForegroundColor = ConsoleColor.White;


        }

        public static void displaySubHeading(string[] heading)
        {
            Headings h = new Headings();
            displayHeading(h.SecureCrypt());

            int totalScreenSpace = 118;
            int numElements = heading[0].Length;
            int numSpaces = (totalScreenSpace - numElements)/2;

            float lineLength;
            int SleepTimer = 1;
            int sleepTimerBig = 10;

            //if ((heading != h.Login()) || (heading != h.Register()))
            //    sleepTimerBig = 0;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            foreach (string line in heading)
            {
                for(int i = 0; i < numSpaces; i++)
                {
                    Console.Write(" ");
                }
                System.Threading.Thread.Sleep(sleepTimerBig);
                Console.WriteLine(line);
            }

            lineLength = heading[0].Length / 2;

            for (int k = 0; k < numSpaces; k++)
            {
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (int i = 0; i <= Math.Truncate(lineLength); i++)
            {

                Console.Write("=-");
                System.Threading.Thread.Sleep(SleepTimer);
            }

            Console.WriteLine("v1.0");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void displayText(string text, string[] heading)
        {
            int totalScreenSpace = 118;
            int numElements = heading[0].Length;
            int numSpaces = (totalScreenSpace - numElements) / 2;
            int sleepTimerBig = 10;

            for (int i = 0; i < numSpaces; i++)
            {
                Console.Write(" ");
            }
            System.Threading.Thread.Sleep(sleepTimerBig);
            Console.Write(text);
        }
    }
}