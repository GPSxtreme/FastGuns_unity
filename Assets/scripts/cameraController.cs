using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    
    public static cameraController instance;
    public Transform player;
    public Camera cam;
    private float startFOV,targetFOV;
    public float zoomSpeed ;
    void Awake(){
        instance = this;
    }
    void Start(){
        startFOV = cam.fieldOfView;
        targetFOV = startFOV;
    }
    void LateUpdate()
    {
        transform.position = player.position;
        transform.rotation = player.rotation;
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView,targetFOV,zoomSpeed*Time.deltaTime);
    }
    public void zoomIn(float newZoom){
        targetFOV = newZoom;
    }
    public void zoomOut(){
        targetFOV = startFOV;
    }
}
