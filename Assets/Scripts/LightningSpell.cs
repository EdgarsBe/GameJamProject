using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpell : MonoBehaviour
{
    public float speed = 15f;
    public int damage = 2;
    public float range = 1f;
    public GameObject impactEffect;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("Range", range);
    }

    void Range()
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage enemy = collision.GetComponent<TakeDamage>();
        if (enemy != null)
        {
            enemy.GivenDamage(damage);
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
