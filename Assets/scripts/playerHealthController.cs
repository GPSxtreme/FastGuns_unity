using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class playerHealthController : MonoBehaviour
{
    public float currentHealth ;
    public float maxHealth = 50f;

    void Start (){
        currentHealth = maxHealth;
        uiController.instance.healthSlider.maxValue = maxHealth;
        uiController.instance.healthSlider.value = currentHealth;
        uiController.instance.healthText.text = "HEALTH: "+ currentHealth +"/"+ maxHealth;

    }
    public void damagePlayer(float dmgAmount){
        currentHealth -= dmgAmount;
        uiController.instance.healthSlider.value = currentHealth;
        uiController.instance.healthText.text = "HEALTH: "+ currentHealth +"/"+ maxHealth;
        if (currentHealth <= (0.42069)*maxHealth)
        {
            uiController.instance.anim.SetBool("isHealthLow",true);
        }
        if(currentHealth <= 0) 
        {
            gameObject.SetActive(false);
            gameManager.instance.restartGame();
        }
    }  
}   

