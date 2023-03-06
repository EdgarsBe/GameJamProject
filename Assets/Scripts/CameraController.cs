using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;


    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(player.position.x, -8.95f, 8.95f),
            Mathf.Clamp(player.position.y, -1.37f, 4.28f), 
            transform.position.z);  
    }
}
