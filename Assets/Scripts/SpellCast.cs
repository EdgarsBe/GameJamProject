using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCast : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Spell;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Cast();
        }
    }

    void Cast() 
    {
        Instantiate(Spell, firePoint.position, firePoint.rotation);
    }
}
