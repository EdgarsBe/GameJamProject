using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SekeltonAI : MonoBehaviour
{
    [Header("Patroling")]
    [SerializeField] float Speed;
    private float Direction = 1;
    private bool faceingRight = true;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform wallCheck;
    [SerializeField] LayerMask GroundLayer;
    [SerializeField] float circleRadius;
    [SerializeField] bool CheckingGround;
    [SerializeField] bool CheckingWall;

    private Rigidbody2D enemyRG;

    // Start is called before the first frame update
    private void OnEnable()
    {
        Health.GameOver += DisableMovement;
    }

    private void OnDisable()
    {
        Health.GameOver -= DisableMovement;
    }

    void Start()
    {
        enemyRG = GetComponent<Rigidbody2D>();
        EnableMovement();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckingGround = Physics2D.OverlapCircle(groundCheck.position, circleRadius, GroundLayer);
        CheckingWall = Physics2D.OverlapCircle(wallCheck.position, circleRadius, GroundLayer);
        Patroling();
    }

    void Patroling()
    {
        if (CheckingGround || CheckingWall)
        {
            if (faceingRight)
            {
                Flip();
            }
            else if (!faceingRight)
            {
                Flip();
            }
        }
        enemyRG.velocity = new Vector2(Speed * Direction, enemyRG.velocity.y);
    }

    void Flip()
    {
        Direction *= -1;
        faceingRight = !faceingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void DisableMovement()
    {
        enemyRG.bodyType = RigidbodyType2D.Static;
    }

    private void EnableMovement()
    {
        enemyRG.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, circleRadius);
        Gizmos.DrawWireSphere(wallCheck.position, circleRadius);
    }
}
