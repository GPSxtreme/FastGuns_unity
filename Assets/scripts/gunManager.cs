using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunManager : MonoBehaviour
{
    public static gunManager instance;
    public GameObject bullet;
    public bool canAutoFire;
    public float fireRate;
    [HideInInspector]
    public float fireCounter;
    public int currentAmmo;
    public int maxAmmoPerClip = 30;
    public Transform firePoint;
    public float zoomAmount;
    public string gunName;
   
    // Start is called before the first frame update
    void Awake(){
        instance = this;
    }
    void Start()
    {
        currentAmmo = maxAmmoPerClip;
    }

    // Update is called once per frame
    void Update()
    {
        if(fireCounter>0)
        fireCounter -=Time.deltaTime;
        updateAmmoUi();
    }
     public void ammoPickupFull(){
        currentAmmo = maxAmmoPerClip;
        updateAmmoUi();
    }
    public void updateAmmoUi(){
        uiController.instance.ammoText.text = "AMMO: " + currentAmmo;
    }
    
}
