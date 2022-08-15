using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    Enemy.Factory _enemyFactory;
    [SerializeField] int maxNumberOfEnemy = 5;
    [SerializeField] int currentNumberOfEnemy;
    [Range(0, 1)]
    [SerializeField] float chanceToGold = 0.2f;
    public float spawnRate = 0.2f;
    public float speedEnemy = 3f;

    [Inject]
    void Construct(Enemy.Factory enemyFactory)
    {
        _enemyFactory = enemyFactory;
        _enemyFactory.Load();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        while (ShouldSpawnNewEnemy())
        {
            yield return new WaitForSeconds(spawnRate);
            if (chanceToGold < Random.Range(0f, 1f))
            {
                _enemyFactory.Create(EnemyType.Simple, ScreenBounds.RandomBottomPosition(),speedEnemy);
            }
            else
            {
                _enemyFactory.Create(EnemyType.Gold, ScreenBounds.RandomBottomPosition(), speedEnemy);
            }
            currentNumberOfEnemy++;
        }
    }
    public void DecreaseNumberOfEnemy()
    {
        currentNumberOfEnemy--;
    }
    bool ShouldSpawnNewEnemy()
    {
        return maxNumberOfEnemy > currentNumberOfEnemy;
    }
}
