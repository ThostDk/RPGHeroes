
namespace RPGHeroes
{
    public static class Player
    {
        private static Hero ?_hero;
        public static Hero Hero { get => _hero; set => _hero = value; }

        public static void AddHero(Hero hero)
        {
            if (hero != null)
            {
                _hero = hero;
            }
            else
            {
                throw new ChosenHeroNotFoundException("The selected Hero choice doesn't exist", nameof(hero));
            }
           
        }
    }
}
