using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCast : MonoBehaviour
{
    public float SpellDelay;
    public float SpellDelay2;
    public float SpellDelay3;
    private float nextFire;
    private float nextFire2;
    private float nextFire3;
    public Transform firePoint;
    public GameObject FireSpell;
    public GameObject IceSpell;
    public GameObject LightningSpell;
    public PlayerMovement Player;
    private Animator CastAnim;

    private void Start()
    {
        CastAnim = GetComponent<Animator>();
    }
    void Update()
    {
        if(Player.canMove)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Cast1();
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                Cast2();
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                Cast3();
            }
        }
    }

    void Cast1() 
    {
        if (Time.time > nextFire)
        {
            CastAnim.SetBool("Pressed", true);
            nextFire = Time.time + SpellDelay;
            Instantiate(FireSpell, firePoint.position, firePoint.rotation);
            Invoke("AnimStop", 0.5f);
        }
    }
    void Cast2()
    {
        if (Time.time > nextFire2)
        {
            CastAnim.SetBool("Pressed", true);
            nextFire2 = Time.time + SpellDelay2;
            Instantiate(IceSpell, firePoint.position, firePoint.rotation);
            Invoke("AnimStop", 0.5f);
        }
    }
    void Cast3()
    {
        if (Time.time > nextFire3)
        {
            CastAnim.SetBool("Pressed", true);
            nextFire3 = Time.time + SpellDelay3;
            Instantiate(LightningSpell, firePoint.position, firePoint.rotation);
            Invoke("AnimStop", 0.5f);
        }
    }

    void AnimStop()
    {
        CastAnim.SetBool("Pressed", false);
    }
}
