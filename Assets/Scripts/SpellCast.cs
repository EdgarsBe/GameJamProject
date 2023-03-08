using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCast : MonoBehaviour
{
    public float SpellDelay;
    private float nextFire;
    public Transform firePoint;
    public GameObject FireSpell;
    public GameObject IceSpell;
    public GameObject LightningSpell;
    public PlayerMovement Player;

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
            nextFire = Time.time + SpellDelay;
            Instantiate(FireSpell, firePoint.position, firePoint.rotation);
        }
    }
    void Cast2()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + SpellDelay;
            Instantiate(IceSpell, firePoint.position, firePoint.rotation);
        }
    }
    void Cast3()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + SpellDelay;
            Instantiate(LightningSpell, firePoint.position, firePoint.rotation);
        }
    }
}
