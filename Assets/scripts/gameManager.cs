using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public float waitTimeAfterDying = 2f;
    public AudioMixer masterMixer;
    
    void Awake(){
        instance = this ;
    }
    
    void Start()
    {
        Time.timeScale =  1;
        Cursor.lockState = CursorLockMode.Locked;
        uiController.instance.pauseMenuAnimControl.keepAnimatorControllerStateOnDisable = true;
        //set volume of sfx and music 
        masterMixer. SetFloat("masterVolume",PlayerPrefs.GetInt("masterVolume"));
        masterMixer.SetFloat("musicVolume",PlayerPrefs.GetInt("musicVolume"));
        masterMixer.SetFloat("sfxVolume",PlayerPrefs.GetInt("sfxVolume"));
    }
    
    void Update(){
      
      if(Input.GetKey(KeyCode.L)){
            restartGame();
        }
        if(Input.GetKeyDown(KeyCode.Escape)&& uiController.instance.optionsScreen.activeInHierarchy == false){
           pauseUnpause();
        }
    }
    
    public void restartGame(){
        audioManager.instance.playSfx(13);
        StartCoroutine(playerDied());
    }
    
    // better Invoke method(simultaneously run two functions at a time in a function)
    public IEnumerator playerDied(){
        yield return new WaitForSeconds(waitTimeAfterDying);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void pauseUnpause(){
        if(uiController.instance.pauseScreen.activeInHierarchy){
            uiController.instance.pauseScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            playerController.instance.footStepFast.Play();
            playerController.instance.footStepSlow.Play();

        }else
        {
            uiController.instance.pauseScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            playerController.instance.footStepFast.Stop();
            playerController.instance.footStepSlow.Stop();
        }
    }
}
