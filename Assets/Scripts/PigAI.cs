using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigAI : MonoBehaviour
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

    [Header("Charging")]
    [SerializeField] float speedMulti;
    [SerializeField] Transform player;
    [SerializeField] Transform GroundCheck;
    [SerializeField] Vector2 boxSize;
    [SerializeField] int mass;
    private bool isGrounded;

    [Header("Seeing")]
    [SerializeField] Vector2 lineOfSight;
    [SerializeField] LayerMask playerMask;
    private bool canSeePlayer;

    private Rigidbody2D enemyRG;
    private Animator pigAnim;

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
        pigAnim = GetComponent<Animator>();
        EnableMovement();
    }

    private void Update()
    {
        Physics2D.IgnoreLayerCollision(8,8);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckingGround = Physics2D.OverlapCircle(groundCheck.position, circleRadius, GroundLayer);
        CheckingWall = Physics2D.OverlapCircle(wallCheck.position, circleRadius, GroundLayer);
        isGrounded = Physics2D.OverlapBox(GroundCheck.position, boxSize, 0, GroundLayer);
        canSeePlayer = Physics2D.OverlapBox(transform.position, lineOfSight, 0, playerMask);
        Animations();
        if (!canSeePlayer && isGrounded)
        {
            Patroling();
        }
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

    void ChargeAttack()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;

        if (isGrounded)
        {
            enemyRG.velocity = new Vector2(speedMulti * Direction, enemyRG.velocity.y);
        }
    }

    void FlipTowardsPlayer()
    {
        float playerPosition = player.position.x - transform.position.x;
        if (playerPosition < 0 && faceingRight)
        {
            Flip();
        }
        else if (playerPosition > 0 && !faceingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Direction *= -1;
        faceingRight = !faceingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void Animations()
    {
        pigAnim.SetBool("canSeePlayer", canSeePlayer);
        pigAnim.SetBool("isGrounded", isGrounded);
    }

    private void DisableMovement()
    {
        pigAnim.enabled = false;
        enemyRG.bodyType = RigidbodyType2D.Static;
    }

    private void EnableMovement()
    {
        pigAnim.enabled = true;
        enemyRG.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, circleRadius);
        Gizmos.DrawWireSphere(wallCheck.position, circleRadius);
        Gizmos.DrawCube(GroundCheck.position, boxSize);
        Gizmos.DrawWireCube(transform.position, lineOfSight);
    }
}
