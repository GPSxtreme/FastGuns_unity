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
    public GameObject continueBtn;
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
       // setResolution(PlayerPrefs.GetInt("resolutionX"),PlayerPrefs.GetInt("resolutionY"));
        setQuality(PlayerPrefs.GetInt("qualityIndex"));
        //setting up resume btn
        if(PlayerPrefs.HasKey("contLvl")){
            if(PlayerPrefs.GetString("contLvl") == ""){
                continueBtn.SetActive(false);
            }
        }
        else{
            continueBtn.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
            if(PlayerPrefs.GetString("contLvl") == "lvl0"&& PlayerPrefs.GetString("lvl0" + "_cp") == ""){
                continueBtn.SetActive(false);
            }
            
    }
    
    public void setResolution(int resolutionX, int resolutionY){
        Screen.SetResolution(resolutionX,resolutionY,Screen.fullScreen);
    }
    public void setQuality (int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void resume(){
        SceneManager.LoadScene(PlayerPrefs.GetString("contLvl"));
    }
    public void exit(){
        Application.Quit();
        Debug.Log("exit");
    }
    public void LoadLvl1(){
        PlayerPrefs.SetString("contLvl","");
        PlayerPrefs.SetString("lvl0" + "_cp","");
        PlayerPrefs.SetString("lvl1" + "_cp","");
        PlayerPrefs.SetString("lvl2" + "_cp","");
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
