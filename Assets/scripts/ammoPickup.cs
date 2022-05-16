using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoPickup : MonoBehaviour
{
    [SerializeField] string pickupType;
    private int cAmmo;
    private int mAmmo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cAmmo = gunManager.instance.currentAmmo;
        mAmmo = gunManager.instance.maxAmmoPerClip;
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"&& cAmmo != mAmmo){
            gunManager.instance.ammoPickupFull();
        }
        Destroy(gameObject);
    }
}