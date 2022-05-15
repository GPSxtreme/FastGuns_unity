using UnityEngine;

public class enemyHealthController : MonoBehaviour
{
    public float currentHealth ; 
    public float maxHealth = 10f;
    
    void Start (){
        currentHealth = maxHealth;
    }
    public void damageEnemy(float dmgAmount){
        currentHealth -= dmgAmount;
        if(currentHealth <=0) Destroy(gameObject);
    }
}
