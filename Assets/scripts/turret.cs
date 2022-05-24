using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public GameObject bullet;
    public float rangeToTargetPlayer,timeBtwShots = 0.5f;
   // public float turretDmgAmount;
    public float shotCounter;
    public Transform gun,firePoint;
    public float rotateSpeed = 1f ;
    public float rotateDistance=10f;
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = timeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {  
        if(Vector3.Distance(transform.position,playerController.instance.transform.position)<rangeToTargetPlayer){
            gun.LookAt(playerController.instance.transform.position+new Vector3(0,0.2f,0));
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0){
                Instantiate(bullet,firePoint.position,firePoint.rotation);
                shotCounter = timeBtwShots;
            }
        }
        else
        {
            shotCounter = timeBtwShots;
            gun.rotation = Quaternion.Lerp(gun.rotation,Quaternion.Euler(0f,gun.rotation.eulerAngles.y + rotateDistance,0f),rotateSpeed*Time.deltaTime);
        }
        
    }
}
