public class EnemyPointer
{
    public static readonly Entity Chaser = new Entity
    {
        maxHealth = 100f,
        speed = 5f,
        damage = 5f,
    };
    
    public static readonly Entity Kamikaze = new Entity
    {
        maxHealth = 40f,
        speed = 7f,
        damage = 15f,
    };


    public static readonly Entity Archer = new Entity
    {
        maxHealth = 75f,
        speed = 2f,
        damage = 7f
    };
}
