using System;
namespace Asteroid.Prototype
{
    [Serializable]
    internal sealed class Hp
    {
        public float MaxHP;
        public float CurrentHP;
        public override string ToString()
        {
            return $"MaxHP {MaxHP} CurrentHP {CurrentHP}";
        }
    }
}

