using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(9,6);

        if (Input.GetKeyDown(KeyCode.F))
        {
            FireSpell();
        }
    }

    void FireSpell()
    {
        anim.SetBool("FireSpell", true);
    }
}
