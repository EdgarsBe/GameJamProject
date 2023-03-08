using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpell : MonoBehaviour
{
    public float speed = 7f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    void OnTriggerEnter2D( Collider2D hitinfo)
    {
        Debug.Log(hitinfo.name);
        Destroy(gameObject);
    }
}
