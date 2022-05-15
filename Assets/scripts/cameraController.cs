using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform player;
    void LateUpdate()
    {
        transform.position = player.position;
        transform.rotation = player.rotation;
    }
}
