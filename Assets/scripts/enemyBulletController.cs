using UnityEngine;

public class enemyBulletController : MonoBehaviour
{
    public float moveSpeed,lifeTime;
    public Rigidbody rB;
    public GameObject impactEffect;
    public GameObject impactFxSphere;
    public float dmgAmount;
   // public bool dmgEnemy,dmgPlayer;

    void Update()
    {
        rB.velocity = transform.forward*moveSpeed;

        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "enemy"){
         other.gameObject.GetComponent<enemyHealthController>().damageEnemy(dmgAmount);
        }
        if(other.gameObject.tag == "Player")
        {
        other.gameObject.GetComponent<playerHealthController>().damagePlayer(dmgAmount);
        }
        if(other.gameObject.tag == "obstacles"){
           Destroy(gameObject);
        }
       
        Instantiate(impactEffect,transform.position+(transform.forward*(-moveSpeed*Time.deltaTime)),transform.rotation); 
    }
}
