using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool castSpell = false;
    public Transform firePoint;
    public GameObject Spell;
    public Transform player;
    public Transform castPoint;
    public float shootRange;
    bool isFacingRight;
    Rigidbody2D rb2d;

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (CanSeePlayer(shootRange)) // If within shooting distance - shoots
        {
            ShootPlayer();
        }

    }

    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = -distance;
        
        Vector2 endPos = castPoint.position + Vector3.right * distance;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if(hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            val = false;
        }
        
        Debug.DrawLine(castPoint.position, endPos, Color.white);

        return val;
    } 

    void ShootPlayer()
    {
        if (transform.position.x < player.position.x)
        {
            transform.localScale = new Vector2(1, 1);
            isFacingRight = true;
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
            isFacingRight = false;
        }
    }

    public void Cast()
    {
        Instantiate(Spell, firePoint.position, firePoint.rotation);
    }

}
