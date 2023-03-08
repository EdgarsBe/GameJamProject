using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] int damage;
    public static float health;
    [SerializeField] float maxHealth = 5;
    public Health playerHealth;


    private void Start()
    {
        health = maxHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }

    public void GivenDamage(int TakenDamage)
    {
        health -= TakenDamage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
