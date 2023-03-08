using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpell : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Debug.Log(hitinfo.name);
        Destroy(gameObject);
    }
}
