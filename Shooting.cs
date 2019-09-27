﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;

    [Serializable] float cooldown = 1F;
    float timeStamp = 0.0F;

    void Update()
    {
        if (Input.GetButton("Fire1") && timeStamp <= Time.time)
        {
            timeStamp = Time.time + cooldown;
            Shoot();
        }
    }

    void Shoot()
    {
        Vector2 origin = firePoint.transform.position;
        Vector2 direction = firePoint.transform.right;
        [Serializable] int bulletForce = 100;  // Puede fallar
        
        RaycastHit2D rayHit = Physics2D.Raycast(origin, direction, 100f, LayerMask.GetMask("Enemy"));
        Debug.Log(rayHit.collider);
        if (rayHit.collider != null)
        {
            rayHit.rigidbody.AddForceAtPosition(direction * bulletForce, rayHit.point);
        }
    }
}
