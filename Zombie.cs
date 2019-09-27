using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    [Serializable] float zombieSpeed = 0.4f;
    // [Serializable] float zombieDamage = 1f;
    // [Serializable] float zombieHealth = 2f;

    void Update()
    {
	    ZombieMove();
    }

    void ZombieMove()
    {
        Vector3 movement = new Vector3.left;
        transform.translate += movement * zombieSpeed * Time.deltaTime;
    }
}
