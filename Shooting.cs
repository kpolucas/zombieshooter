using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;

    float cooldown = 1F;
    float timeStamp = 0.0F;
    float ammo = 6;

    void Update()
    {
        if (Input.GetButton("Fire1") && CanFire())
        {
            Shoot();
	    timeStamp = Time.time + cooldown;
        }

	if (Input.GetKeyDown("r"))
	{
	    Reload();
	}
    }

    void Shoot()
    {
        Vector2 origin = firePoint.transform.position;
        Vector2 direction = firePoint.transform.right;
        int bulletForce = 100;
        
        RaycastHit2D rayHit = Physics2D.Raycast(origin, direction, 100f, LayerMask.GetMask("Enemy"));
        Debug.Log(rayHit.collider);
        if (rayHit.collider != null)
        {
            rayHit.rigidbody.AddForceAtPosition(direction * bulletForce, rayHit.point);
        }
	ammo--;
    }

    void Reload() // COROUTINEAR o timestampear aplicar lo mas adaptable al Reload cool
    {
	ammo = 6;
    }
    
    bool CanFire()
    {
        return (timeStamp <= Time.time && ammo > 0); // && !reloading);
    }
}
