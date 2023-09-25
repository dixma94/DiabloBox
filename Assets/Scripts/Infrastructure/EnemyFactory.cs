
using UnityEngine;
using Zenject;

public class EnemyFactory
{
    private const string EnemyRat = "Rat";

    private Object enemyRat;

    private readonly DiContainer container;

    public EnemyFactory(DiContainer container)
    {
        this.container = container;
    }


    public void Load()
    {
        enemyRat = Resources.Load(EnemyRat);


    }

    public Rat Create( Vector3 at)
    {
        return container.InstantiatePrefab(enemyRat, at, Quaternion.identity, null).GetComponent<Rat>();
    }
}



