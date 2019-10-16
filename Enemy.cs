using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float speed = 0.4f;
    int currentHealth = 2;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void Damage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Destroy(gameObject); // falta agregar animacion
        }
        else
        {
            StartCoroutine(ChangeColor()); // falta agregar animacion
        }
    }


    IEnumerator ChangeColor()
    {
        var originalColor = rend.material.color;
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rend.material.color = originalColor;
    }
}