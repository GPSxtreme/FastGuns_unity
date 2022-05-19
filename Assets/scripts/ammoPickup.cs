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
        cAmmo = playerController.instance.activeGun.currentAmmo;
        mAmmo = playerController.instance.activeGun.maxAmmoPerClip;
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"&& cAmmo != mAmmo){
           playerController.instance.activeGun.ammoPickupFull();
            Destroy(gameObject);
        }
        
    }
}
