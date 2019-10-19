using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float speed = 0.4f;
    int currentHealth = 2;
    Renderer rend;
    Animator animator;

    void Start()
    {
        rend = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(8,8);
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
            StartCoroutine(DeathAnimation());
        }
        else
        {
            StartCoroutine(DamageAnimation());
        }
    }




    IEnumerator DamageAnimation()
    {
        var originalColor = rend.material.color;
        rend.material.color = new Color(1f, 0.7f, 0.7f, 1f);
        animator.SetBool("damaged", true);
        yield return new WaitForSeconds(0.5f);
        rend.material.color = originalColor;
        animator.SetBool("damaged", false);
    }

    IEnumerator DeathAnimation()
    {
        speed = 0f;
        animator.SetBool("death", true);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}