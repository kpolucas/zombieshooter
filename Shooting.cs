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
        if (Input.GetButton("Fire1") && timeStamp <= Time.time)
        {
            timeStamp = Time.time + cooldown;
	        if (ammo > 0) {
            	Shoot();
		        Debug.Log(ammo);
	        }
        }

	    if (Input.GetKeyDown("r"))
	    {
	        Reload();
	        Debug.Log(ammo);
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

    void Reload()
    {
	ammo = 6;
    }
}
