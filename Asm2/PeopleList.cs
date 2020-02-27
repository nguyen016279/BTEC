using System;
using System.Collections.Generic;

namespace Asm2
{
    public class PeopleList : IList  
	    {  
	        private LinkedList<Person> list = new LinkedList<Person>();  
	  
	        public PeopleList()
	        {  
	        }  
	  
	        public void addPerson(Person person)
	        {  
	            list.AddFirst(person);  
	        }  
	        public void update(Person oldPerson, Person newPerson)
	        {  
	            list.Find(oldPerson).Value = newPerson;  
	        }  
	  
	        public void delete(Person person)
	        {  
                list.Remove(person);  
	        }  
	  
	        public IIterator createIterator()
	        {  
	            return new PeopleIterator(list);  
	        }  
	  
	    }  

}
