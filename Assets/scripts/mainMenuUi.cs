using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class mainMenuUi : MonoBehaviour
{   public GameObject settingMenu;
    public AudioMixer masterMixer;

    [SerializeField] float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //set volume of sfx and music 
        masterMixer. SetFloat("masterVolume",PlayerPrefs.GetInt("masterVolume"));
        masterMixer.SetFloat("musicVolume",PlayerPrefs.GetInt("musicVolume"));
        masterMixer.SetFloat("sfxVolume",PlayerPrefs.GetInt("sfxVolume"));
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
        settingsMenu.instance.masterVolumeSlider.value = PlayerPrefs.GetInt("masterVolume");
        settingsMenu.instance.musicVolumeSlider.value = PlayerPrefs.GetInt("musicVolume");
        settingsMenu.instance.sfxVolumeSlider.value = PlayerPrefs.GetInt("sfxVolume");
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
