using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class victoryScreen : MonoBehaviour
{
    public GameObject gameOverTxt;
    public GameObject mainMenuBtn;
    [SerializeField] float delayTime;
    public Image blackScreen;
    [SerializeField] float blackScreenInitialOpacity;
    public float blackScreenFadeSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        blackScreenInitialOpacity = blackScreen.color.a;
        delayTime = 1f;
        blackScreenFadeSpeed = 0.5f;
        gameOverTxt.SetActive(false);
        mainMenuBtn.SetActive(false);
    }
    void Start(){
        blackScreen.color = new Color(blackScreen.color.r,blackScreen.color.g,blackScreen.color.b,1f);
        StartCoroutine(showObjectsCo());
    }
    // Update is called once per frame
    void Update()
    {
        blackScreen.color = new Color(blackScreen.color.r,blackScreen.color.g,blackScreen.color.b,Mathf.MoveTowards(blackScreen.color.a,blackScreenInitialOpacity,blackScreenFadeSpeed*Time.deltaTime));
    }
    public IEnumerator showObjectsCo(){
        yield return new  WaitForSeconds(delayTime);
        gameOverTxt.SetActive(true);
        yield return new  WaitForSeconds(delayTime);
        mainMenuBtn.SetActive(true);
    }
    public void mainMenuReturn(){
        SceneManager.LoadScene("mainMenu");
    }
}
