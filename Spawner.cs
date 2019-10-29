using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy[] enemiesArray = new Enemy[2];
    Enemy enemyClone;
    [SerializeField]
    float cooldown = 2f;
    float timer;
    int randIndx;


    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        randIndx = Random.Range(0, enemiesArray.Length);
        enemyClone = Instantiate(enemiesArray[randIndx], transform.position, transform.rotation) as Enemy;
        timer = cooldown;
    }
}
