using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthSystemCommon : MonoBehaviour
{
    public static enemyHealthSystemCommon instance;
    public float maxHealth;
    public float currentHealth;
    public float lowHealthIndicationNo;
    public ParticleSystem effectUponLowHealth;
    public ParticleSystem effectUponDestroy;
    public bool hasLowHealthFx;
    private bool lowHealthFxOn;
    private bool destroyFxOn;
    public bool hasDestroyFx;
    
    void Awake(){
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        lowHealthFxOn = false;
        destroyFxOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <=lowHealthIndicationNo && hasLowHealthFx && lowHealthFxOn == false){
            Instantiate(effectUponLowHealth,transform.position,transform.rotation);
        }
        if(currentHealth <= 0 && destroyFxOn == false){
            lowHealthFxOn = true;
            Destroy(gameObject);
            if(hasDestroyFx)
            Instantiate(effectUponDestroy,transform.position,transform.rotation);
            destroyFxOn = true;
        }
    }
    /*
    private void OnTriggerEnter(Collider other){
       if(other.gameObject.tag == "playerBullet"){
           currentHealth -= dmgToBeTaken;
        }
    }
    */
    public void damage(float dmgAmount){
        currentHealth -= dmgAmount;
    }
}
