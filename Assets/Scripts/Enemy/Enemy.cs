using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    public class Factory : PlaceholderFactory<Enemy>
    {
        readonly DiContainer _container;
        const string simpleGhost = "SimpleGhost";
        const string goldGhost = "GoldGhost";
        Object _simpleGhostPrefab;
        Object _goldGhostPrefab;

        public Factory(DiContainer diContainer)
        {
            _container = diContainer;
        }
        public void Load()
        {
            _simpleGhostPrefab = Resources.Load(simpleGhost);
            _goldGhostPrefab = Resources.Load(goldGhost);
        }
        public void Create(EnemyType enemyType, Vector2 spawnpoint,float speed)
        {
            GameObject enemy;
            switch (enemyType)
            {
                case EnemyType.Simple:
                    enemy = _container.InstantiatePrefab(_simpleGhostPrefab, spawnpoint, Quaternion.Euler(0, 0, -90), null);
                    break;
                case EnemyType.Gold:
                    enemy = _container.InstantiatePrefab(_goldGhostPrefab, spawnpoint, Quaternion.Euler(0, 0, -90), null);
                    break;
                default:
                    enemy = null;
                    break;
            }
            if(enemy!=null)
                enemy.GetComponent<EnemyMovement>().speed = speed;
        }
    }
}
