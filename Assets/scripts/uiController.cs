using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class uiController : MonoBehaviour
{
    public static uiController instance;
    public Slider healthSlider;
    public Text healthText;
    public Animator anim;
    public void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
