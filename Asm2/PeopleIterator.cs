using System;
using System.Collections.Generic;
using System.Linq;
using Asm2;

namespace Asm2
	{  
	    public class PeopleIterator : IIterator  
	    {  
	        private LinkedList<Person> peopleList;  
	        private int position;  
	        public PeopleIterator(LinkedList<Person> peopleList)
	        {  
	            this.peopleList = peopleList;  
	        }  
	  
	        public Person CurrentItem()
	        {  
	            return peopleList.ElementAt(position);  
	        }  
	  
	        public void First()
	        {  
	            position = 0;  
	        }  
	  
	        public bool IsDone()
	        {  
	            return position >= peopleList.Count;  
	        }  
	  
	        public Person Next()
	        {  
	            return peopleList.ElementAt(position++);  
	        }  
	    }  
	}  
