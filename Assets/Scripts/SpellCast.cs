using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCast : MonoBehaviour
{
    public Transform firePoint;
    public GameObject FireSpell;
    public GameObject IceSpell;
    public GameObject LightningSpell;
    void Update()
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

    void Cast1() 
    {
        Instantiate(FireSpell, firePoint.position, firePoint.rotation);
    }
    void Cast2()
    {
        Instantiate(IceSpell, firePoint.position, firePoint.rotation);
    }
    void Cast3()
    {
        Instantiate(LightningSpell, firePoint.position, firePoint.rotation);
    }
}
