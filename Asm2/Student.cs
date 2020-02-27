using System;
namespace Asm2
{
	    public class Student : Person  
	    {  
	        private string batch;  
	  
	        public Student()
	        {  
	  
	        }  
	  
	        public Student(string id, string name, string birthday, string email, string address, string batch)
	        {  
	            this.Id = id;  
	            this.Name = name;  
	            this.Birthday = birthday;  
	            this.Email = email;  
	            this.Address = address;  
	            this.Batch = batch;  
	        }  
	  
	        public string Batch
	        {  
	            get { return this.batch; }  
	            set { this.batch = value; }  
	        }  
	  
	        public override string Display()
	        {  
	            return base.Display() + "\t|\t" +  
	                    this.batch;  
	        }  
	    }  

}
