using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlExit : MonoBehaviour
{
    public string nxtLvl;
    public float delayTime;
    void Start()
    {
        
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
        SceneManager.LoadScene(nxtLvl);
    }
}
