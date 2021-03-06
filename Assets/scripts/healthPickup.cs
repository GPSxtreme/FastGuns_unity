using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{
    public static healthPickup instance;
    [SerializeField] string pickupType;
    float cHealth,mHealth;
    // Start is called before the first frame update
    void Awake(){
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cHealth = playerHealthController.instance.currentHealth;
        mHealth =  playerHealthController.instance.maxHealth;
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player" && cHealth != mHealth){
           if( cHealth < mHealth ){
                audioManager.instance.playSfx(12);
                playerHealthController.instance.maxHealPlayer();
            }
            Destroy(this.gameObject);   
        }
    }
}
