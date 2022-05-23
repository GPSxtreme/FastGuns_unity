using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resume(){
        gameManager.instance.pauseUnpause();
    }
    public void mainMenu(){
        SceneManager.LoadScene("mainMenu");
    }
    public void settingsMenu(){
        uiController.instance.optionsScreen.SetActive(true);
    }
}
