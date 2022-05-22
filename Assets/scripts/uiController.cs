using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class uiController : MonoBehaviour
{
    public static uiController instance;
    public Slider healthSlider;
    public Text healthText;
    public Text ammoText;

    public Animator anim;
    public Image dmgFx;
    public float dmgAlpha = 0.25f,dmgFadeSpeed = 2f;
    public GameObject pauseScreen;
    public GameObject optionsScreen;
    public Animator pauseMenuAnimControl;
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
        if(dmgFx.color.a != 0)
        dmgFx.color = new Color(dmgFx.color.r,dmgFx.color.g,dmgFx.color.b,Mathf.MoveTowards(dmgFx.color.a , 0f , dmgFadeSpeed*Time.deltaTime));
    }
    public void PlayerHit(){
        dmgFx.color = new Color(dmgFx.color.r,dmgFx.color.g,dmgFx.color.b,dmgAlpha);
    }
}
