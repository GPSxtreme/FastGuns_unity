using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuUi : MonoBehaviour
{   public GameObject settingMenu;
    [SerializeField] float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 1;
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
        
       StartCoroutine(waitForAnim(waitTime));
    }
    public void settingsMenuOpen(){
        settingMenu.SetActive(true);
    }
    public void settingsMenuClose(){
        settingMenu.SetActive(false);
    }
    public IEnumerator waitForAnim(float waitTime){
        lvlLoader.instance.triggerAnimation();
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); 
    }
}
