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
        PlayerPrefs.SetString("contLvl","");
        PlayerPrefs.SetString("lvl0" + "_cp","");
        PlayerPrefs.SetString("lvl1" + "_cp","");
        PlayerPrefs.SetString("lvl2" + "_cp","");
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
        lvlLoader.instance.triggerAnimation();
        StartCoroutine(endAnimCo());
    }
    private IEnumerator endAnimCo(){
        yield return new  WaitForSeconds(1f);
        SceneManager.LoadScene("mainMenu");
    }
}
