using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeObstacle : MonoBehaviour
{
    [SerializeField] int damage;
    public Health playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player hit!");
            Debug.Log(damage);
        }
    }

}
