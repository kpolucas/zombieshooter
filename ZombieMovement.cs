﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{

	// ESTE SCRIPT DEBERIA MORIR, LA LOGICA PASO A Zombie.cs
    [Serializable] float zombieSpeed = 0.4f;

    void Update()
    {
        Vector3 movement = new Vector3.left;
        transform.translate += movement * zombieSpeed * Time.deltaTime;
    }
}
