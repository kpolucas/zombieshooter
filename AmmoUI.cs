using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    public Image[] bullets;
    public int currentAmmo;
    Shooting shooting;

    private void Awake()
    {
        shooting = GetComponent < Shooting > ();
    }
    private void Update()
    {
        currentAmmo = shooting.ammo;
        for (int i = 0; i < bullets.Length; i++)
        {
            // revisar, se que hay una forma mas linda de hacerlo
            if (i < currentAmmo)
            {
                bullets[i].enabled = true;
            }
            else
            {
                bullets[i].enabled = false;
            }
        }
    }
}
