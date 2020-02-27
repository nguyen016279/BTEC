using System;
namespace Asm2
{
    public class Lecturer : Person  
	    {  
	        private string department;  
	        public Lecturer()
	        {  
	        }  
	        public Lecturer(string id, string name, string birthday, string email, string address, string department)
	        {  
	            this.Id = id;  
	            this.Name = name;  
	            this.Birthday = birthday;  
	            this.Email = email;  
	            this.Address = address;  
	            this.Department = department;  
	        }  
	  
	        public string Department
	        {  
	            get { return this.department; }  
	            set { this.department = value; }  
	        }  
	  
	        public override string Display()
	        {  
	            return base.Display() + "\t|\t" +  
	                    this.department;  
	        }  
	    }  

}
