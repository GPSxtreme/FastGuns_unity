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
    }
    void Update(){
      if(Input.GetKey(KeyCode.L)){
            restartGame();
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
}
