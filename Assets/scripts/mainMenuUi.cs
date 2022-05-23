using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuUi : MonoBehaviour
{   
    public Animator btnsAnimControl;
    public GameObject settingMenu;

    // Start is called before the first frame update
    void Start()
    {
        //btnsAnimControl.keepAnimatorControllerStateOnDisable = true;
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void exit(){
        Application.Quit();
        Debug.Log("exit");
    }
    public void LoadLvl1(){
        SceneManager.LoadScene("buildLvl"); 
    }
    public void settingsMenuOpen(){
        settingMenu.SetActive(true);
    }
    public void settingsMenuClose(){
        settingMenu.SetActive(false);
    }
}
