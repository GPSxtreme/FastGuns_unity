using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class mainMenuUi : MonoBehaviour
{   
    public static mainMenuUi instance;
    public GameObject settingMenu;
    public AudioMixer masterMixer;
    Resolution[] resolutions;
    [SerializeField] float waitTime = 1f;

    // Start is called before the first frame update
    public void Awake(){
        instance = this;
    }
    void Start()
    {
        //set volume of sfx and music 
        masterMixer. SetFloat("masterVolume",PlayerPrefs.GetInt("masterVolume"));
        masterMixer.SetFloat("musicVolume",PlayerPrefs.GetInt("musicVolume"));
        masterMixer.SetFloat("sfxVolume",PlayerPrefs.GetInt("sfxVolume"));
        //set quality and resolution
        setResolution(PlayerPrefs.GetInt("resolutionX"),PlayerPrefs.GetInt("resolutionY"));
        setQuality(PlayerPrefs.GetInt("qualityIndex"));
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void setResolution(int resolutionX, int resolutionY){
        Screen.SetResolution(resolutionX,resolutionY,Screen.fullScreen);
    }
    public void setQuality (int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
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
    public void settingsMenuClose(){
        settingMenu.SetActive(false);
    }
    public IEnumerator waitForAnim(float waitTime){
        lvlLoader.instance.triggerAnimation();
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); 
    }
}
