using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueSys : MonoBehaviour
{
    public float StartDelayTime;
    public float dialogueLifeTime;
    public Animator DialogueAnim;
    public GameObject DB,DT;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startCo());
        StartCoroutine(endCo());
    }
    private IEnumerator startCo(){
        yield return new WaitForSeconds(StartDelayTime);
        DB.SetActive(true);
        DT.SetActive(true);
        DialogueAnim.Play("dialogueEntry");
    }
    private IEnumerator endCo(){
        yield return new WaitForSeconds(dialogueLifeTime);
        DialogueAnim.SetTrigger("hide");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
