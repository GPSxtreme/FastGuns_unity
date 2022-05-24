using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class lvlLoader : MonoBehaviour
{
    public static lvlLoader instance;
    public Animator anim;
    public CanvasGroup cg;
    
    void Awake(){
        instance = this;
    }
    void start(){
        cg.alpha = 1;
    }
    void Update()
    {
        
    }
    public void triggerAnimation(){
        anim.SetTrigger("start");
    }    
}
