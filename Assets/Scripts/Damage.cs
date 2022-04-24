using UnityEngine;
namespace Asteroid
{
    public sealed class Damage :  IDamage
    {
        public float healthPoints { get; set; }
        
        public void Hit(GameObject player)
        {
            if (healthPoints <= 0)
            {
                player.SetActive(false);
            }
            else
            {
                healthPoints--;
            }
        }
    }
}