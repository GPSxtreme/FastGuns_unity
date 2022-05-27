using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncePad : MonoBehaviour
{
   public float bouncePadStrength;
   
   private void OnTriggerEnter(Collider other){
       if(other.gameObject.tag == "Player"){
           playerController.instance.playerBounce(bouncePadStrength);
           audioManager.instance.playSfx(0);
       }
   }
}
