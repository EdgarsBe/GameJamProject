using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] public float health;
    [SerializeField] float maxHealth = 5;
    public Health playerHealth;
    public HealthBar HealthBar;


    private void Start()
    {
        health = maxHealth;
        HealthBar.SetHealth(health, maxHealth);
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
        HealthBar.SetHealth(health, maxHealth);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
