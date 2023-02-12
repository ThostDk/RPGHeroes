using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Exceptions
{
    public class ChosenHeroNotFoundException : Exception
    {
        public ChosenHeroNotFoundException() { }
        
        public ChosenHeroNotFoundException(string message) : base(message)
        {

        }
        public ChosenHeroNotFoundException(string message, Exception furtherException) : base(message, furtherException)
        {
            
        }
    }
   
}
