using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{ 
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject Spell;
    [SerializeField] GameObject player;
    [SerializeField] GameObject castPoint;
    [SerializeField] float seeRange;
    [SerializeField] float speed;
    private bool isFacingRight;
    Rigidbody2D rb2d;
    private float movingDirection;
    [SerializeField] int delay = 3;
    float timer;
    private bool spellCooldown = false;


    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distToPlayer < 3f)
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
            Cast();
        }
        else
        {
            rb2d.constraints = RigidbodyConstraints2D.None;
        }

        /*if (CanSeePlayer(seeRange))
        {
            ChasePlayer();
        }*/

    }

    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        if (!isFacingRight)
        {
            castDist = -distance;
        }



        movingDirection = transform.localScale.x;
        Vector2 endPos = castPoint.transform.position + Vector3.right * castDist * movingDirection;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.transform.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }

            Debug.DrawLine(castPoint.transform.position, hit.point, Color.red);

        } else
        {
            Debug.DrawLine(castPoint.transform.position, endPos, Color.white);
        }

        return val;
    } 

    /*void ChasePlayer()
    {
        if (transform.position.x < player.transform.position.x)
        {
            rb2d.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(1, 1);
            isFacingRight = true;
        }
        else
        {
            rb2d.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-1, 1);
            isFacingRight = false;
        }
    }*/

    public void Cast()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            Instantiate(Spell, firePoint.position, firePoint.rotation);
            spellCooldown = true;
            timer = 0;
        }
    }

}
