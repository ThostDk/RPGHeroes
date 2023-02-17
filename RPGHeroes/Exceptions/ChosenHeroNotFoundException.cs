
namespace RPGHeroes
{
    public class ChosenHeroNotFoundException : Exception
    {
        public ChosenHeroNotFoundException(string message) { }
        
        public ChosenHeroNotFoundException(string message, string? hero) : base(message + $": {hero}")
        {

        }
        
    }
   
}
