using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSwapper : MonoBehaviour
{
    public gunManager laserPistol,laserAutoGun,laserSniper;
    public GameObject laserPistolGO,laserAutoGunGO,laserSniperGO;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1)){
            disableAllGuns();
            playerController.instance.activeGun = laserPistol; 
            
            laserPistolGO.SetActive(true);
        }
         if(Input.GetKey(KeyCode.Alpha2)){
            disableAllGuns();
            playerController.instance.activeGun = laserAutoGun;
            
            laserAutoGunGO.SetActive(true);
        }
         if(Input.GetKey(KeyCode.Alpha3)){
            disableAllGuns();
            playerController.instance.activeGun = laserSniper;
            
            laserSniperGO.SetActive(true); 
        }
    }
    public void disableAllGuns(){
        laserPistolGO.SetActive(false);
        laserAutoGunGO.SetActive(false);
        laserSniperGO.SetActive(false);
    }
}
