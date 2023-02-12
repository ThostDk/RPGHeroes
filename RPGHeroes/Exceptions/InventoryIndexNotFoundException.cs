using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Exceptions
{
    public class InventoryIndexNotFoundException : Exception
    {
        public InventoryIndexNotFoundException() { }
        
        public InventoryIndexNotFoundException(string message, int index) : base(message + $": {index}")
        {
        }
        public InventoryIndexNotFoundException(string message, Exception furtherException) : base(message, furtherException)
        {
            
        }
    }
   
}
