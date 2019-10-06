using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;

    float cooldown = 1F;
    float timeStamp = 0.0F;
    float ammo = 6;
    int bulletForce = 180;

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
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, 100f, LayerMask.GetMask("Enemy"));

        if (hit.collider != null)
        {
            hit.rigidbody.AddForceAtPosition(direction * bulletForce, hit.point);
            //
            hit.collider.GetComponent<Enemy>().Damage();
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

