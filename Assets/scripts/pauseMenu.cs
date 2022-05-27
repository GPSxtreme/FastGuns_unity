using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pauseMenu : MonoBehaviour
{
    public List<Animator> allBtnAnims = new List<Animator>();
    [SerializeField] float waitTime = 1f;
    // Start is called before the first frame update
    void Start()
    {   
        for(int i= 0 ; i < allBtnAnims.Count ; i++){
            allBtnAnims[i].updateMode = AnimatorUpdateMode.UnscaledTime;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resume(){
        gameManager.instance.pauseUnpause();
    }
    public void mainMenu(){
        Time.timeScale = 1;
        StartCoroutine(waitForAnim(waitTime));
    }
    public void settingsMenuOpen(){
        uiController.instance.optionsScreen.SetActive(true);
        settingsMenu.instance.masterVolumeSlider.value = PlayerPrefs.GetInt("masterVolume");
        settingsMenu.instance.musicVolumeSlider.value = PlayerPrefs.GetInt("musicVolume");
        settingsMenu.instance.sfxVolumeSlider.value = PlayerPrefs.GetInt("sfxVolume");
    }
    public IEnumerator waitForAnim(float waitTime){
        lvlLoader.instance.triggerAnimation();
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("mainMenu"); 
    }
}
