using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public float waitTimeAfterDying = 2f;
    
    void Awake(){
        instance = this ;
    }
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        uiController.instance.pauseMenuAnimControl.keepAnimatorControllerStateOnDisable = true; 
    }
    
    void Update(){
      if(Input.GetKey(KeyCode.L)){
            restartGame();
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
           pauseUnpause();
        }
    }
    
    public void restartGame(){
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
