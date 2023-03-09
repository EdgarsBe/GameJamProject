using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : MonoBehaviour
{
    public float speed = 10f;
    public float range = 10f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public int damage = 5;

    void Start()
    {
            rb.velocity = transform.right * speed;
            Invoke("Range", range);
    }

    private void Update()
    {
        Physics2D.IgnoreLayerCollision(9, 9);
    }
    void Range()
    {
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
