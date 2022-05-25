using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class exploderEnemy : MonoBehaviour
{
    public float distanceToChase;
    public float damage;
    public float speed;
    public bool chasePlayer;
    public GameObject impactFx;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,playerController.instance.transform.position)<=distanceToChase){
            chasePlayer = true;
        }
        if(chasePlayer){
            transform.LookAt(playerController.instance.transform.position);
            transform.position = Vector3.MoveTowards(transform.position,playerController.instance.transform.position,speed*Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            playerHealthController.instance.damagePlayer(damage);
            audioManager.instance.playSfx(3);
            uiController.instance.PlayerHit();
            Instantiate(impactFx,transform.position,transform.rotation);
            Destroy(gameObject);
            chasePlayer = false;
        }
    }
}
