using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{

    public float speed;
    Rigidbody2D enemyRigidBody;


    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(IsFacingRight())
        {
            enemyRigidBody.velocity = new Vector2(speed, 0f);
        } else {
            enemyRigidBody.velocity = new Vector2(-speed, 0f);

        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidBody.velocity.x)) * 5, transform.localScale.y);
    }
}
