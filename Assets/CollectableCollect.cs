using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableCollect : MonoBehaviour
{
    private int shoes = 0;
    [SerializeField] private Text Counter;
    [SerializeField] private AudioSource CollectSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            CollectSFX.Play();
            Destroy(collision.gameObject);
            shoes++;
            Counter.text = "" + shoes;
        }
    }
}
