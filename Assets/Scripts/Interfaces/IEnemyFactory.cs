namespace Asteroid
{
    internal interface IEnemyFactory
    {
        Enemy Create(Health healthPoints);
    }
}