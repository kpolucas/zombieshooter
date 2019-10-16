using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemy;
    Enemy enemyClone;
    [SerializeField]
    float cooldown = 2f;
    float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            enemyClone = Instantiate(enemy, transform.position, transform.rotation) as Enemy;
            timer = cooldown;
        }
    }
}
