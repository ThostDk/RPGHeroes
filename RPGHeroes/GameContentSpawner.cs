
namespace RPGHeroes
{
    //Singleton for singular global access to game content
    public sealed class GameContentSpawner
    {
        // ItemFactories
        ArmorFactory _armorFactory = new ArmorFactory();
        WeaponFactory _weaponFactory = new WeaponFactory();
        EnemyFactory _enemyFactory= new EnemyFactory();
        List<Armor> _armors = new List<Armor>();
        List<Weapon> _weapons = new List<Weapon>();
        List<Enemy> _enemies = new List<Enemy>();
        private static readonly GameContentSpawner instance = new GameContentSpawner();

        static GameContentSpawner()
        {
            
        }
        private GameContentSpawner()
        {
            foreach (Equipment item in _armorFactory.CreateEquipment())
            {
                _armors.Add((Armor)item);
            }
            foreach (Equipment item in _weaponFactory.CreateEquipment())
            {
                _weapons.Add((Weapon)item);
            }
            _enemies = _enemyFactory.CreateEnemy();
        }
        public static GameContentSpawner Instance
        {
            get
            {
                return instance;
            }
        }
        

        public List<Armor> Armors { get => _armors; set => _armors = value; }
        public List<Enemy> Enemies { get => _enemies; set => _enemies = value; }
        public List<Weapon> Weapons { get => _weapons; set => _weapons = value; }
    }
}
