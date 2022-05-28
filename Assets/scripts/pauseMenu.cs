using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pauseMenu : MonoBehaviour
{
    public List<Animator> allBtnAnims = new List<Animator>();
    [SerializeField] float waitTime = 1f;
    private int resolIndex;

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
        //update settings 
        settingsMenu.instance.masterVolumeSlider.value = PlayerPrefs.GetInt("masterVolume");
        settingsMenu.instance.musicVolumeSlider.value = PlayerPrefs.GetInt("musicVolume");
        settingsMenu.instance.sfxVolumeSlider.value = PlayerPrefs.GetInt("sfxVolume");
        settingsMenu.instance.graphicsDropDown.value = PlayerPrefs.GetInt("qualityIndex");
        settingsMenu.instance.graphicsDropDown.RefreshShownValue();
        StartCoroutine(resolCo());
    }
    private IEnumerator resolCo(){
        yield return new WaitForSeconds(0.01f);
        settingsMenu.instance.resolutionDropDown.value = PlayerPrefs.GetInt("resolutionIndex");
        settingsMenu.instance.resolutionDropDown.RefreshShownValue();
    }
    public IEnumerator waitForAnim(float waitTime){
        lvlLoader.instance.triggerAnimation();
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("mainMenu"); 
    }
}
