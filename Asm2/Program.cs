using System;

namespace Asm2
{
 	    class Program
	    {  
        static void Main(string[] args)
	        {  
	           // initialize  
	           string[] mainMenuAcceptedAnswer = { "1", "2", "3" };  
	              
	           while (true)  
	            {  
	                // show main menu  
	                Console.Clear();  
	                Console.WriteLine("=======================");  
	                Console.WriteLine("1. Manage Students");  
	                Console.WriteLine("2. Manage Lecturers");  
	                Console.WriteLine("3. Exit");  
	                Console.WriteLine("=======================");  
	  
	                // ask user input the answer until they input correct  
	                string ans = "";  
	                while (Array.IndexOf(mainMenuAcceptedAnswer, ans) == -1)  
	                {  
	                    Console.WriteLine("Please choose submenu? ");  
	                    ans = Console.ReadLine();  
	                }   
	  
	                switch (ans)  
	                {  
	                    case "1":  
	                        // student management  
	                        StudentModule stdModule = StudentModule.GetInstance();  
	                        stdModule.open();  
	                        break;  
	                    case "2":  
	                        // lecturer management  
	                        LecturerModule lecModule = LecturerModule.GetInstance();  
	                        lecModule.open();  
	                        break;  
	                    case "3":  
	                        // exist  
	                        return;  
	                }  
	            }  
	  
	            //Console.ReadKey();  
	        }  
	    }  

}
