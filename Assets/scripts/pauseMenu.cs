using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pauseMenu : MonoBehaviour
{
    public List<Animator> allBtnAnims = new List<Animator>();
    [SerializeField] float waitTime = 0.3f;
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
    public void settingsMenu(){
        uiController.instance.optionsScreen.SetActive(true);
    }
    public IEnumerator waitForAnim(float waitTime){
        lvlLoader.instance.triggerAnimation();
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("mainMenu"); 
    }
}
