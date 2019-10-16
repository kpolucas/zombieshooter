using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;

    [SerializeField] float cooldown = 1F;
    [SerializeField] int bulletForce = 180;
    [SerializeField] float reloadTime = 2;
    public int ammo = 6;
    public AudioSource reloadingSound;
    bool reloading = false;
    float timeStamp = 0.0F;

    private void Start()
    {
        reloadingSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && CanFire())
        {
            Shoot();
	        timeStamp = Time.time + cooldown;
        }
	    if (Input.GetKeyDown("r") && !reloading)
	    {
            StartCoroutine(Reload());
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
            hit.collider.GetComponent<Enemy>().Damage();
        }
	    ammo--;
    }

    IEnumerator Reload()
    {
        reloading = true;
        reloadingSound.Play();
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
        ammo = 6;
    }

    bool CanFire()
    {
        return (timeStamp <= Time.time && ammo > 0 && !reloading);
    }
}

