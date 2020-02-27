using System;
namespace Asm2
{
    public class StudentModule : IPeopleManagement  
	    {  
	        private static StudentModule instance = new StudentModule();  
	        private PeopleList studentList = new PeopleList();  
	  
	        private StudentModule()
	        {  
	        }  
	        public static StudentModule GetInstance()
	        {  
	            return instance;  
	        }  
	  
	        public void open()
	        {  
	            Console.WriteLine("Student Management open");  
	            string[] subMenuAcceptedAnswer = { "1", "2", "3", "4", "5", "6" };  
	  
	            // Add some sample student  
	            studentList.addPerson(new Student("GT00001", "Xuan Nguyen", "01/01/1991", "xuannguyen@gmail.com", "Ha Noi", "Computing"));  
	            studentList.addPerson(new Student("GT00002", "Captain America", "2/03/1992", "captain@gmail.com", "New York", "Action"));  
	            studentList.addPerson(new Student("GT00003", "Harry Portter", "12/04/1993", "harryportter@gmail.com", "Hog warst", "Action"));  
	            studentList.addPerson(new Student("GC00001", "Black widow", "26/05/1981", "blackwidow@gmail.com", "New York", "Action"));  
	            studentList.addPerson(new Student("GC00002", "Neymar jr", "15/06/1971", "neymarjr@gmail.com", "Brazil", "Sport"));  
	  
	            while (true)  
	            {  
	                // show Student Management menu  
	                Console.Clear();  
	                Console.WriteLine("=======================");  
	                Console.WriteLine("1. Add new student");  
	                Console.WriteLine("2. View all students");  
	                Console.WriteLine("3. Search students");
                    Console.WriteLine("4. Delete students");  
                    Console.WriteLine("5. Update student");  
	                Console.WriteLine("6. Back to main menu");  
	                Console.WriteLine("=======================");  
	  
	                // ask user input the answer until they input correct  
	                string ans = "";  
	                while (Array.IndexOf(subMenuAcceptedAnswer, ans) == -1)  
	                {  
	                    Console.WriteLine("Please choose action? ");  
	                    ans = Console.ReadLine();  
	                }  
	  
	                switch (ans)  
	                {  
	                    // Add Student Function  
	                    case "1":  
	                        AddStudent(); break;  
	  
	                    // Show all students  
	                    case "2":  
	                        ShowAllStudent(); break;  
	  
	                    // Search students  
	                    case "3":  
	                        SearchStudent(); break;  
	  
	                    // Delete student  
	                    case "4":  
	                        DeleteStudent(); break;  
	  
	                    // Update student  
	                    case "5":  
	                        UpdateStudent(); break;  
  
	                    case "6":  
	  
	                        return;  
	                }  
	            }  
	        }  	          
	        private void AddStudent()
	        {  
	            // Input Student Id  
	            string id;  
	            do  
	            {  
	                Console.WriteLine("Input ID, must be GTXXXXX or GCXXXXX with X is a digit.");  
	                id = Console.ReadLine();  
	            } while (!Utils.checkStudentId(id));  
	  
	            // Input Student Name  
	            Console.WriteLine("Input name: ");  
	            string name = Console.ReadLine();  
	  
	            // Input day of birth  
	            string birthday;  
	            do  
	            {  
	                Console.WriteLine("Input birthday, must be a valid date format MM/DD/YYYY ");  
	                birthday = Console.ReadLine();  
	            } while (!Utils.checkDateFormat(birthday));  
	  
	            // Input Student Email  
	            string email;
                Console.WriteLine("Input email, must be valid email format, ex: example@host.com ");
			    email = Console.ReadLine();
			    while (!Utils.checkEmail(email))
                {
				Console.WriteLine("Input email, must be valid email format, ex: example@host.com ");
				email = Console.ReadLine();
			    }
	  
	            // Input Student Address  
	            Console.WriteLine("Input address: ");  
	            string address = Console.ReadLine();  
	  
	            // Input Student Batch  
	            Console.WriteLine("Input batch: ");  
	            string batch = Console.ReadLine();   
	            Student std = new Student
	            {  
	                Id = id,  
	                Name = name,  
	                Birthday = birthday,  
	                Email = email,  
	                Address = address,  
	                Batch = batch  
	            };  	  
	            // add student to student list  
	            studentList.addPerson(std);  
	            Console.WriteLine("Add student successfully");  	  
	            Console.WriteLine("Press any key to continue...");  
	            Console.ReadKey();  
	        }  
	
	        private void ShowAllStudent()
	        {  
	            IIterator iterator = studentList.createIterator();  
	            Console.WriteLine("List all student:");  
	            while (!iterator.IsDone())  
	            {  
	                Console.WriteLine(iterator.Next().Display());  
	            }  
	  
	            Console.WriteLine("Press any key to continue...");  
	            Console.ReadKey();  
	        }  
	  
	        private void SearchStudent()
	        {  
	            Console.WriteLine("Enter the name of the student to search:");  
	            string keyword = Console.ReadLine();  
	            IIterator iterator = studentList.createIterator();  
	            while (!iterator.IsDone())  
	            {  
	                if (iterator.CurrentItem().Name.IndexOf(keyword, StringComparison.Ordinal) > -1)  
                    {  
	                    Console.WriteLine(iterator.CurrentItem().Display());  
	                }  
	                iterator.Next();  
	            }  
	            Console.WriteLine("Press any key to continue...");  
	            Console.ReadKey();  
	        }  
	  
	        private void UpdateStudent()
	        {  
	            string id = Utils.askForKeyword("Input student Id:");  
	            Student std = SearchStudentById(id);  
	            if (std != null)  
	            {  
	                // Input Student Name  
	                Console.WriteLine("Input name: Old name = " + std.Name);  
	                string name = Console.ReadLine();  
	                name = name == "" ? std.Name : name;  	  
	                // Input day of birth  
	                string birthday;  
	                do  
	                {  
	                    Console.WriteLine("Input birthday, must be a valid date format DD/MM/YYYY : Old birthday = " + std.Birthday);  
	                    birthday = Console.ReadLine();  
	                } while (birthday != "" && !Utils.checkDateFormat(birthday));  
	                birthday = birthday == "" ? std.Birthday : birthday;  
	  
	                // Input Student Email  
	                string email;
                    Console.WriteLine("Input email, must be valid email format, ex: example@host.com ");
	     			email = Console.ReadLine();
	    			while (!Utils.checkEmail(email))
     				{
    					Console.WriteLine("Input email, must be valid email format, ex: example@host.com ");
    					email = Console.ReadLine();
    				}
	    			email = email == "" ? std.Email : email;  
	                // Input Student Address  
	                Console.WriteLine("Input address: ");  
	                string address = Console.ReadLine();  
	                address = address == "" ? std.Address : address;  
	                // Input Student Batch  
	                Console.WriteLine("Input batch: ");  
	                string batch = Console.ReadLine();  
	                batch = batch == "" ? std.Batch : batch;  
	                Student newStudent = new Student
	                {  
	                    Id = id,  
	                    Name = name,  
	                    Birthday = birthday,  
	                    Email = email,  
	                    Address = address,  
	                    Batch = batch  
	                };  
	                studentList.update(std, newStudent);  
	                Console.WriteLine("Updated!");  
	            }  else  {  
	                Console.WriteLine("Id is not exist!");  
	            }  
	            Console.WriteLine("Press any key to continue...");  
	            Console.ReadKey();  
	        }  
	  
	        private Student SearchStudentById(string id)
	        {  
	            Student result = null;  
	            IIterator iterator = studentList.createIterator();  
	            while (!iterator.IsDone())  
	            {  
	                if(iterator.CurrentItem().Id == id)  
	                {  
	                    result = iterator.CurrentItem() as Student;  
	                }  
	                iterator.Next();  
	            }  
	            return result;  
            }  
  
	        private void DeleteStudent()
	        {  
	            string id = Utils.askForKeyword("Input student Id:");  
	            Student std = SearchStudentById(id);  
	            if (std != null)  
	            {  
	                studentList.delete(std);
		    		Console.WriteLine("Delete successful");
	            }  
	            else  
	            {  
	                Console.WriteLine("Student is not exist!");  
	            }  
	            Console.WriteLine("Press any key to continue...");  
	            Console.ReadKey();  
	        }          
	    }  

}
