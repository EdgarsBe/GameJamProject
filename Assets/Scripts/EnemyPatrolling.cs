using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    public float speed;
    Rigidbody2D enemyRigidBody;
    public bool allowedToMove = true;

    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (IsFacingRight() && allowedToMove)
        {
            enemyRigidBody.velocity = new Vector2(speed, 0f);
        }
        else if (allowedToMove)
        {
            enemyRigidBody.velocity = new Vector2(-speed, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidBody.velocity.x)), transform.localScale.y);
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("monke");
            allowedToMove = false;
            enemyRigidBody.velocity = Vector2.zero;
        }
        else
        {
            transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidBody.velocity.x)), transform.localScale.y);
            allowedToMove = true;
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
}
