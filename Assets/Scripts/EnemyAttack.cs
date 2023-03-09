using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject Spell;
    [SerializeField] GameObject player;
    [SerializeField] GameObject castPoint;
    [SerializeField] float seeRange;
    [SerializeField] float castRange;
    [SerializeField] float speed;
    [SerializeField] LayerMask maskDetection;
    [SerializeField] LayerMask maskSpell;
    Rigidbody2D rb2d;
    private float movingDirection;
    [SerializeField] int delay = 3;
    float timer;


    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Physics2D.IgnoreLayerCollision(8, 9);
        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (CanSeePlayer(seeRange))
        {
            RaycastHit2D hit = Physics2D.Raycast(firePoint.position, Vector3.right * this.transform.localScale.x, castRange, maskSpell);

            Debug.DrawRay(firePoint.position, Vector3.right * castRange * this.transform.localScale.x);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<PlayerMovement>())
            {
                Cast();
            }
        }
        else
        {
            rb2d.constraints = RigidbodyConstraints2D.None;
        }



    }

    bool CanSeePlayer(float distance)
    {
        bool val = false;
        movingDirection = transform.localScale.x;
        transform.localScale = new Vector2(movingDirection, 1f);
        RaycastHit2D hit = Physics2D.Raycast(castPoint.transform.position, Vector3.right * this.transform.localScale.x, seeRange, maskDetection);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.GetComponent<PlayerMovement>())
            {
                val = true;
            }
            else
            {
                val = false;
            }
        }

        return val;
    }

    public void Cast()
    {
        rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
        timer += Time.deltaTime;
        if (timer > delay)
        {
            if (transform.localScale.x < 1f)
            {
                GameObject.Find("SpellPoint").transform.eulerAngles = new Vector3(0, 180, 0);
            }
            Instantiate(Spell, firePoint.position, firePoint.rotation);
            timer = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(castPoint.transform.position, Vector3.right * seeRange * this.transform.localScale.x);
    }

}
