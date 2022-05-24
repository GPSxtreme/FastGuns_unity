using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class lvlLoader : MonoBehaviour
{
    public static lvlLoader instance;
    public Animator transitionAnim;
    public CanvasGroup transitionCanvasGrp;
    public Image transitionImg;
    
    void Awake(){
        instance = this;
    }
    void start(){
        //the below code doesn't work for fek sake..... :(
        transitionCanvasGrp.alpha = 1;
        transitionImg.GetComponent<CanvasGroup>().alpha = 1;
    }
    void Update()
    {
        
    }
    public void triggerAnimation(){
        transitionAnim.SetTrigger("start");
    }    
}
