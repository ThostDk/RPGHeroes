
namespace RPGHeroes
{
    public class EquipItemItemNotFoundException : Exception
    {
        public EquipItemItemNotFoundException() { }
        
        public EquipItemItemNotFoundException(string? message, string? item) : base(message + $": {item}")
        {
        }
        public EquipItemItemNotFoundException(string message, Exception furtherException) : base(message, furtherException)
        {
            
        }
        
    }
   
}
