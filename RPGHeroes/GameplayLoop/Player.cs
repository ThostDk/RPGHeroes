using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.GameplayLoop
{
    public static class Player
    {
        private static Hero _hero;
        public static Hero Hero { get => _hero; set => _hero = value; }

    }
}
