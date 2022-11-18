partial class Program
{


    static void TaskIsCompleted(int taskNum)
    {
        string selectedTaskName = Tasks[taskNum];
        Console.WriteLine($"{selectedTaskName}: ");
    }






    static List<DateTime> StartTime = new List<DateTime>()
{
DateTime.MinValue,
DateTime.MinValue,
DateTime.MinValue,
DateTime.MinValue,
DateTime.MinValue,
DateTime.MinValue,
DateTime.MinValue,
DateTime.MinValue,
DateTime.MinValue,
DateTime.MinValue,
};





    static List<DateTime> EndTime = new List<DateTime>()
{
DateTime.MinValue,
DateTime.MinValue,
DateTime.MinValue,
DateTime.MinValue,
DateTime.MinValue,
DateTime.MinValue,
DateTime.MinValue,
DateTime.MinValue,
DateTime.MinValue,
DateTime.MinValue,
};
    static List<string> Tasks = new List<string>() {
"Wake up",
"Have breakfast",
"Brush your teeth",
"Go for classes",
"Take a break",
"Have lunch",
"Do homework",
"Go to the gym",
"Study",
"Go to bed",
};





    static bool Completed(int taskNum)
    {
        DateTime now = DateTime.Now;
        if (now >= EndTime[taskNum])
        {
            return true;
        }
        else
        {
            return false;
        }
    }




    static void Main(string[] args)
    {
        Console.WriteLine("Welcome Do you want to open the program? Type 'y' if you want to start");
        string response = Console.ReadLine();


        if (response == "y")
        {

        }


        if (response == "y")
        {
            Random rnd = new Random();
            int i = rnd.Next(10);


            if (i == 0)
            {
                Console.WriteLine("Welcome!");
            }

            if (i == 1)
            {
                Console.WriteLine("Hi!");
            }
            if (i == 2)
            {
                Console.WriteLine("Hello!");
            }
            if (i == 3)
            {
                Console.WriteLine("Welcome!");
            }
            if (i == 4)
            {
                Console.WriteLine("Bienvenido!");
            }
            if (i == 5)
            {
                Console.WriteLine("Willkommen!");
            }
            if (i == 6)
            {
                Console.WriteLine("Bienvenue!");
            }
            if (i == 7)
            {
                Console.WriteLine("Bem-vindo!");
            }
            if (i == 8)
            {
                Console.WriteLine("Hello there!");
            }
            if (i == 9)
            {
                Console.WriteLine("What's up!");
            }
        }
        
    


        string locationFile = "C:\\repos\\C#\\Lab10\\Lab10AndresEguez\\stats.csv";
        System.IO.StreamReader file = new System.IO.StreamReader(locationFile);
        string separator = ",";
        string line;
        file.ReadLine();
        while ((line = file.ReadLine()) != null)
        {
            string[] row = line.Split(separator);
            string toDoItems = row[0];
            string completedItems = row[1];
            double averageTime = Convert.ToDouble(row[2]);
            int itemsCreatedPerDay = Convert.ToInt32(row[3]);
        }



        bool exit = false;
        Console.WriteLine("Welcome to your to-do board. Here are your tasks for today: ");





        foreach (string list in Tasks)
        {
            Console.WriteLine(list);
        }




        while (!exit)
        {





            Console.WriteLine("Please select a task");
            //loop over the data store and print out a menu entry for each task we're tracking
            for (int i = 0; i < Tasks.Count; i++)
            {
                //print the array index and description of each task
                String menuItem = $"{i}: {Tasks[i]}";
                //also print the completion state of the item
                if (EndTime[i] > DateTime.MinValue)
                {
                    menuItem = menuItem + $" (Completed at {EndTime[i]})";
                }
                else if (StartTime[i] > DateTime.MinValue)
                {
                    menuItem = menuItem + $" (Started at {StartTime[i]})";
                }
                else
                {
                    menuItem = menuItem + " (Not Started)";
                }

                Console.WriteLine(menuItem);
            }
            Console.WriteLine($"{Tasks.Count}: Exit");




            int opCode = int.Parse(Console.ReadLine());
            Console.WriteLine();





            DateTime now = DateTime.Now;
            string time = now.GetDateTimeFormats('t')[0];
            DateTime startTime = DateTime.Now;
            DateTime endTime;
            startTime = DateTime.Now;
            endTime = startTime.AddMinutes(10);
            TimeSpan t = endTime - startTime;





            if (opCode >= 0 && opCode < Tasks.Count)
            {
                if (Completed(opCode))
                {
                    TaskIsCompleted(opCode);
                }
            }
            else if (opCode == Tasks.Count)
            {
                Console.WriteLine("Goodbye!");
                Console.ReadKey();
                Console.Clear();
            }

            //add submenu here, to handle task specific updates
            Console.WriteLine("How would you like to update the task?");
            Console.WriteLine("   (1) Start the task");
            Console.WriteLine("   (2) Finish the task");
            Console.WriteLine("   (3) Reset the task");
            Console.WriteLine("   (4) No changes, nevermind");


            int subCode = int.Parse(Console.ReadLine());

            switch (subCode)
            {
                case 1: //start the task
                    StartTime[opCode] = DateTime.Now;
                    break;


                case 2: //end the task
                    EndTime[opCode] = DateTime.Now;
                    break;


                case 3: //reset the task
                    StartTime[opCode] = DateTime.MinValue;
                    EndTime[opCode] = DateTime.MinValue;
                    break;

                case 4:
                    break; //no operation, user changed their mind


                default: //bad choice!
                    Console.WriteLine("That was an invalid choice.");
                    break;
            }



        }
    }
}