using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : MonoBehaviour
{
    public float speed = 10f;
    public float range = 10f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("Range", range);
    }
    void Range()
    {
        Destroy(gameObject);
    }

}
