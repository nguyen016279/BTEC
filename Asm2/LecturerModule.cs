using System;
namespace Asm2
{
    public class LecturerModule : IPeopleManagement  
	    {  
	        private static LecturerModule instance = new LecturerModule();  
	        private PeopleList lecturerList = new PeopleList();  
	  
	        private LecturerModule()
	        {  
	        }  
	        public static LecturerModule GetInstance()
	        {  
	            return instance;  
	        }  
	  
	        public void open()
	        {  
	            Console.WriteLine("Lecturer Management open");  
	            string[] subMenuAcceptedAnswer = { "1", "2", "3", "4", "5", "6" };  
	  
	            // Add some sample Lecturer  
	            lecturerList.addPerson(new Lecturer("00000001", "David Milsho", "01/01/1991", "david@gmail.com", "America", "English"));  
	            lecturerList.addPerson(new Lecturer("00000002", "Bui Linh", "2/03/1992", "linh@gmail.com", "Ha Noi", "IT1"));  
	            lecturerList.addPerson(new Lecturer("00000003", "Bao Thoa", "12/04/1993", "thoa@gmail.com", "Ha Noi", "English"));  
	            lecturerList.addPerson(new Lecturer("00000004", "Cao Hien", "26/05/1992", "hien@gmail.com", "Ha Noi", "English"));  
	            lecturerList.addPerson(new Lecturer("00000005", "Phuong Thao", "10/06/1992", "thao@gmail.com", "Ha Noi", "English"));  
	               
	            while (true)  
	            {  
	                // show Lecturer Management menu  
	                Console.Clear();  
	                Console.WriteLine("=======================");  
	                Console.WriteLine("1. Add new Lecturer");  
	                Console.WriteLine("2. View all Lecturers");  
	                Console.WriteLine("3. Search Lecturers");  
	                Console.WriteLine("4. Delete Lecturers");  
	                Console.WriteLine("5. Update Lecturer");  
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
	                    // Add Lecturer Function  
	                    case "1":  
	                        AddLecturer(); break;  
	  
	                    // Show all Lecturers  
	                    case "2":  
	                        ShowAllLecturer(); break;  
	  
	                    // Search Lecturers  
	                    case "3":  
	                        SearchLecturer(); break;  
	  
	                    // Delete Lecturer  
	                    case "4":  
	                        DeleteLecturer(); break;  
	  
	                    // Update Lecturer  
	                    case "5":  
	                        UpdateLecturer(); break;  
	  
	                    case "6":  
	  
	                        return;  
	                }  
	            }  
	        }  
	  
	        private void AddLecturer()
	        {  
	            // Input Lecturer Id  
	            string id;  
	            do  
	            {  
	                Console.WriteLine("Input ID, must be XXXXXXXX with X is a digit.");  
	                id = Console.ReadLine();  
	            } while (!Utils.checkLecturerId(id));  
	  
	            // Input Lecturer Name  
	            Console.WriteLine("Input name: ");  
	            string name = Console.ReadLine();  
	  
	            // Input day of birth  
	            string birthday;  
	            do  
	            {  
	                Console.WriteLine("Input birthday, must be a valid date format MM/DD/YYYY ");  
	                birthday = Console.ReadLine();  
	            } while (!Utils.checkDateFormat(birthday));  
	  
	            // Input Lecturer Email  
	            string email;
		    	Console.WriteLine("Input email, must be valid email format, ex: example@host.com ");
		     	email = Console.ReadLine();
		    	while (!Utils.checkEmail(email))
                {
		     		Console.WriteLine("Input email, must be valid email format, ex: example@host.com ");
			    	email = Console.ReadLine();
			    } 
			    // Input Lecturer Address  
			    Console.WriteLine("Input address: ");  
	            string address = Console.ReadLine();  
	  
	            // Input Lecturer Department  
	            Console.WriteLine("Input department: ");  
	            string department = Console.ReadLine();  
	  
	            Lecturer lecturer = new Lecturer
	            {  
	                Id = id,  
	                Name = name,  
	                Birthday = birthday,  
	                Email = email,  
	                Address = address,  
	                Department = department  
	            };  
	  
	            // add Lecturer to Lecturer list  
	            lecturerList.addPerson(lecturer);  
	            Console.WriteLine("Add Lecturer successfully");  
	  
	            Console.WriteLine("Press any key to continue...");  
	            Console.ReadKey();  
	        }  
	  
	        private void ShowAllLecturer()
	        {  
	            IIterator iterator = lecturerList.createIterator();  
	            Console.WriteLine("List all Lecturer:");  
	            while (!iterator.IsDone())  
	            {  
	                Console.WriteLine(iterator.Next().Display());  
	            }  
	  
	            Console.WriteLine("Press any key to continue...");  
	            Console.ReadKey();  
	        }  
	  
	        private void SearchLecturer()
	        {  
	            Console.WriteLine("Input search text:");  
	            string keyword = Console.ReadLine();  
	            IIterator iterator = lecturerList.createIterator();  
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
	  
	        private void UpdateLecturer()
	        {  
	            string id = Utils.askForKeyword("Input Lecturer Id:");  	  
	            Lecturer lecturer = SearchLecturerById(id);  
	            if (lecturer != null)  
	            {  
	                // Input Lecturer Name  
	                Console.WriteLine("Input name: Old name = " + lecturer.Name);  
	                string name = Console.ReadLine();  
	                name = name == "" ? lecturer.Name : name;  	  
	                // Input day of birth  
	                string birthday;  
	                do  
	                {  
	                    Console.WriteLine("Input birthday, must be a valid date format DD/MM/YYYY : Old birthday = " + lecturer.Birthday);  
	                    birthday = Console.ReadLine();  
	                } while (birthday != "" && !Utils.checkDateFormat(birthday));  
	                birthday = birthday == "" ? lecturer.Birthday : birthday;
                    // Input Lecturer Email  
                    string email;
      				Console.WriteLine("Input email, must be valid email format, ex: example@host.com ");
      				email = Console.ReadLine();
	    			while (!Utils.checkEmail(email))
     				{
	    				Console.WriteLine("Input email, must be valid email format, ex: example@host.com ");
	    				email = Console.ReadLine();
	       			}
	    			email = email == "" ? lecturer.Email : email;  	  
	                // Input Lecturer Address  
	                Console.WriteLine("Input address: ");  
	                string address = Console.ReadLine();  
	                address = address == "" ? lecturer.Address : address;  	  
	                // Input Lecturer Batch  
	                Console.WriteLine("Input batch: ");  
	                string department = Console.ReadLine();  
	                department = department == "" ? lecturer.Department : department;   
	                Lecturer newLecturer = new Lecturer
	                {  
	                    Id = id,  
	                    Name = name,  
	                    Birthday = birthday,  
	                    Email = email,  
	                    Address = address,  
	                    Department = department  
	                };  
	                lecturerList.update(lecturer, newLecturer);  
	                Console.WriteLine("Updated!");  
	            }  
	            else  
	            {  
	                Console.WriteLine("Id is not exist!");  
	            }  
	            Console.WriteLine("Press any key to continue...");  
	            Console.ReadKey();  
	        }  
	  
	        private Lecturer SearchLecturerById(string id)
	        {  
	            Lecturer result = null;  
	            IIterator iterator = lecturerList.createIterator();  
	            while (!iterator.IsDone())  
	            {  
	                if (iterator.CurrentItem().Id == id)  
	                {  
	                    result = iterator.CurrentItem() as Lecturer;  
	                }  
	                iterator.Next();  
	            }  
	            return result;  
	        }  
	  
	        private void DeleteLecturer()
	        {  
	            string id = Utils.askForKeyword("Input Lecturer Id:");  
	                Lecturer lecturer = SearchLecturerById(id);  
     	            if (lecturer != null)  
	                {  
	                     lecturerList.delete(lecturer);
                         Console.WriteLine("Delete successful");
	        		}  
	                else  
	                {  
	                Console.WriteLine("Lecturer is not exist!");  
	                }  
	            Console.WriteLine("Press any key to continue...");  
	            Console.ReadKey();  
	        }  

    }
}
