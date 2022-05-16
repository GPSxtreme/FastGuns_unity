using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunManager : MonoBehaviour
{
    public GameObject bullet;
    public bool canAutoFire;
    public float fireRate;
    [HideInInspector]
    public float fireCounter;
    public int currentAmmo;
    public int maxAmmoPerClip = 30;
   
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmoPerClip;
    }

    // Update is called once per frame
    void Update()
    {
        if(fireCounter>0)
        fireCounter -=Time.deltaTime;
        uiController.instance.ammoText.text = "AMMO: " + currentAmmo;
    }
}
