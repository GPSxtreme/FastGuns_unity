using UnityEngine;
using UnityEngine.SceneManagement;


public class checkPointController : MonoBehaviour
{
    public string cpName;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_cp")){
            if(PlayerPrefs.GetString(SceneManager.GetActiveScene().name + "_cp") == cpName){
                playerController.instance.transform.position = transform.position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Delete)){
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "_cp",null);
        }
    }
    private void OnTriggerEnter (Collider other ){
        if(other.gameObject.tag == "Player"){
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "_cp",cpName);
        }
    }
}
