using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpell : MonoBehaviour
{
    public float speed = 7f;
    public float range = 6f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public int damage = 3;

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
    void OnTriggerEnter2D( Collider2D collision)
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
