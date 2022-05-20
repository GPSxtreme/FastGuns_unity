using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuUi : MonoBehaviour
{
        public List<Button> allBtns = new List<Button>();
        public int highLightedBtn;
         public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        highLightedBtn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            highLightBtn();
            highLightedBtn++;
            if(highLightedBtn == 2) highLightedBtn = 0;
        }
    }
    public void exit(){
        Application.Quit();
        Debug.Log("exit");
    }
    public void LoadLvl1(){
        SceneManager.LoadScene("buildLvl");
    }
    public void highLightBtn(){
      allBtns[highLightedBtn].animator.SetTrigger("Highlighted");
    }
    
}
