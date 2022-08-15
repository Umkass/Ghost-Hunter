using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Simple,
    Gold
}
public class EnemyMovement : MonoBehaviour
{
    private CountScore countScore;
    private EnemySpawner spawner;
    private CountHearts countHearts;
    EnemyType type;
    public float speed = 3f;


    void Awake()
    {
        countScore = FindObjectOfType<CountScore>();
        spawner = FindObjectOfType<EnemySpawner>();
        countHearts = FindObjectOfType<CountHearts>();
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed, Space.World);
        if (ScreenBounds.OutOfBounds(transform.position))
        {
            EnemyDie();
        }
    }
    public void EnemyBurst() //пользователем
    {
        switch (type)
        {
            case EnemyType.Simple:
                countScore.score++;
                break;
            case EnemyType.Gold:
                countScore.score += 2;
                break;
            default:
                break;
        }
        countScore.UpdateScore();
        if (countScore.score % 10 == 0)
        {
            if (spawner.spawnRate > 0.1f)
                spawner.spawnRate -= 0.1f;
            spawner.speedEnemy += 0.5f;
        }
        Destroy(gameObject);
    }

    void EnemyDie() //вышел за экран
    {
        countHearts.DecreaseHeart();
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        spawner.DecreaseNumberOfEnemy();
    }

}
