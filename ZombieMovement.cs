using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{

    float zombieSpeed = 0.4f;
    void Update()
    {
        Vector3 movement = new Vector3(-1, 0, 0);
        transform.position += movement * zombieSpeed * Time.deltaTime;
    }
}
