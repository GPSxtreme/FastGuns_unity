using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public Rigidbody rB;
    public float dmgAmount;
    public bool dmgPlayer;
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "enemy")
         { 
             other.gameObject.GetComponent<enemyHealthController>().damageEnemy(dmgAmount);
         }
        if(other.gameObject.tag == "Player"&&dmgPlayer)
        {
            playerHealthController.instance.damagePlayer(dmgAmount);
        }
        if(other.gameObject.tag == "exploder"||other.gameObject.tag == "turret")
        {
             other.gameObject.GetComponent<enemyHealthSystemCommon>().damage(dmgAmount);
        }
    }
}
