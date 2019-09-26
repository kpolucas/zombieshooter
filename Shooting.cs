using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;

    private float cooldown = 1F;
    private float timeStamp = 0.0F;

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
        int bulletForce = 100; // ordenar, va aca o mas arriba?
        Vector2 origin = firePoint.transform.position;
        Vector2 direction = firePoint.transform.right;
        
        RaycastHit2D rayHit = Physics2D.Raycast(origin, direction); // agregar layermask
        Debug.Log(rayHit.collider);
        if (rayHit.collider != null)
        {
            rayHit.rigidbody.AddForceAtPosition(direction * bulletForce, rayHit.point);
        }
    }
}
