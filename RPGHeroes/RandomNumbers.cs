
namespace RPGHeroes
{
    public static class RandomNumbers
    {
        static Random _randomNr = new Random();

        public static Random RandomNr { get => _randomNr; set => _randomNr = value; }
    }
}
