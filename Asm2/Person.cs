using System;
namespace Asm2
{
    public abstract class Person
	    {  
	        private string id;  
	        private string name;  
	        private string birthday;  
	        private string email;  
	        private string address;  
	  
	        public Person()
	        {  
	        }  
	  
	        public string Id
            {  
	            get { return this.id; }  
	            set { this.id = value; }  
	        }  
	        public string Name
	        {  
	            get { return this.name; }  
	            set { this.name = value; }  
	        }  
	        public string Birthday
	        {  
	            get { return this.birthday; }  
	            set { this.birthday = value; }  
	        }  
	        public string Email
	        {  
	            get { return this.email; }  
	            set { this.email = value; }  
	        }  
	        public string Address
	        {  
	            get { return this.address; }  
	            set { this.address = value; }  
	        }  
	  
	        virtual public string Display()
	        {  
	            return this.id + "\t|\t" +  
	                    this.name + "\t|\t" +  
	                    this.birthday + "\t|\t" +  
	                    this.email + "\t|\t"+
	                    this.address;  
	        }  
	  
	    }  

}
