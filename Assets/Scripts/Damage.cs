using UnityEngine;
namespace Asteroid
{
    public sealed class Damage :  IDamage
    {
        public int healthPoints { get; set; }

        public Damage(int HealthPoints)
        {
            healthPoints = HealthPoints;
        }
        
        public void Hit(GameObject player)
        {
            if (healthPoints > 0)
            {
                healthPoints--;
                Debug.Log(healthPoints);
            }
            if (healthPoints <= 0)
            {
                player.SetActive(false);
            }
        }
    }
}