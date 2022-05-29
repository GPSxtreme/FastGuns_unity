using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlExit : MonoBehaviour
{
    public static lvlExit instance;
    public string nxtLvl;
    public bool loadNxtLvl;
    public bool loadGivenLvl;
    public float delayTime;
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            audioManager.instance.playLvlVictory();
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "_cp",null);
            playerController.instance.isGameEnded = true;
            Cursor.lockState = CursorLockMode.None;
            StartCoroutine(endCo(delayTime));
        }
        
    }
    private IEnumerator endCo(float delayTime){
        lvlLoader.instance.triggerAnimation(); 
        yield return new WaitForSeconds(delayTime);
        if(loadGivenLvl){
            SceneManager.LoadScene(nxtLvl);
        }
        if(loadNxtLvl)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); 
        }
        
    }
}
