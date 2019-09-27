using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    float zombieSpeed = 0.4f;
    // [Serializable] float zombieDamage = 1f;
    // [Serializable] float zombieHealth = 2f;

    void Update()
    {
        ZombieMove();
    }

    void ZombieMove()
    {
        transform.Translate(Vector3.left * zombieSpeed * Time.deltaTime);
    }
}