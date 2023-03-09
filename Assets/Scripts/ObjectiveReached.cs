using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveReached : MonoBehaviour
{
    public GameObject WinMenu;
    [SerializeField] PlayerMovement Move;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Move.canMove = false;
            Time.timeScale = 0f;
            WinMenu.SetActive(true);
        }
    }

}
