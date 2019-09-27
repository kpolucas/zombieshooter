using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{

    [Serializable] float zombieSpeed = 0.4f;

    void Update()
    {
        Vector3 movement = new Vector3.left;
        transform.translate += movement * zombieSpeed * Time.deltaTime;
    }
}
