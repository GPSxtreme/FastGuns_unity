using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class playerHealthController : MonoBehaviour
{
    public static playerHealthController instance;
    public float currentHealth ;
    public float maxHealth = 50f;

    void Awake(){
        instance = this;
    }
    void Start (){
        currentHealth = maxHealth;
        uiController.instance.healthSlider.maxValue = maxHealth;
        uiController.instance.healthSlider.value = currentHealth;
        uiController.instance.healthText.text = "HEALTH: "+ currentHealth +"/"+ maxHealth;

    }
    public void damagePlayer(float dmgAmount){
        audioManager.instance.playSfx(14);
        currentHealth -= dmgAmount;
        updateHealthUi();
        uiController.instance.PlayerHit();
       
        if(currentHealth <= 0) 
        {
            gameObject.SetActive(false);
            gameManager.instance.restartGame();
            audioManager.instance.stopBgm();
        }
    }  
    public void maxHealPlayer(){
        currentHealth = maxHealth;
        updateHealthUi();
    }
    public void updateHealthUi(){
        uiController.instance.healthSlider.value = currentHealth;
        uiController.instance.healthText.text = "HEALTH: "+ currentHealth +"/"+ maxHealth;
         if (currentHealth <= (0.42069)*maxHealth)
        {
            uiController.instance.anim.SetBool("isHealthLow",true);
        }else uiController.instance.anim.SetBool("isHealthLow",false);

    }
}   

