using UnityEngine;
using System;
namespace Asteroid 
{ 
    public sealed class TypeOfEnemy
    {
       public static string RandomEnemy()
        {
            int randomNumber = UnityEngine.Random.Range(0, 2);
            switch (randomNumber)
            {
                case 0:
                    return NameConstants.ASTEROID;
                case 1:
                    return NameConstants.SATELITE;
                default:
                    throw new ArgumentOutOfRangeException(nameof(randomNumber), randomNumber, "Не предусмотрен в программе");
            }
        }
    }
}