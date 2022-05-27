using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settingsMenu : MonoBehaviour
{
    public static settingsMenu instance;
    public AudioMixer masterMixer;
    public Dropdown resolutionDropDown;
    Resolution[] resolutions;
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    
    public void Awake(){
        instance = this;
    }
        
    
    void Start(){
        //setting up with resolutions 
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0 ;
        for(int i=0;i<resolutions.Length;i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                currentResolutionIndex = i;      
            }
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
        
    }
    public void goBack(){
        uiController.instance.optionsScreen.SetActive(false);
    }
    public void setMasterVolume(float volume){
        masterMixer. SetFloat("masterVolume",volume);
        PlayerPrefs.SetInt("masterVolume",((int)volume));
    }
    public void setMusicVolume(float volume){
        masterMixer.SetFloat("musicVolume",volume);
        PlayerPrefs.SetInt("musicVolume",((int)volume));
    }
    public void setSfxVolume(float volume){
        masterMixer.SetFloat("sfxVolume",volume);
        PlayerPrefs.SetInt("sfxVolume",((int)volume));
    }
    public void setQuality (int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void setFullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;
    }
    public void setResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }
}
