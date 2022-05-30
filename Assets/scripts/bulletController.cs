using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float moveSpeed,lifeTime;
    public Rigidbody rB;
    public GameObject impactEffect;
    public GameObject impactFxSphere;
    public float dmgAmount;

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
        if(other.gameObject.tag == "target_sphere"){
            Destroy(other.gameObject);
            Instantiate(impactFxSphere,transform.position+(transform.forward*(-moveSpeed*Time.deltaTime)),transform.rotation);
        }
        if(other.gameObject.tag == "enemy")
         { 
             other.gameObject.GetComponent<enemyHealthController>().damageEnemy(dmgAmount);
         }
         if(other.gameObject.tag == "exploder"||other.gameObject.tag == "turret"){
             other.gameObject.GetComponent<enemyHealthSystemCommon>().damage(dmgAmount);
         }
         if(other.gameObject.tag == "headShot"){
            other.transform.parent.parent.parent.GetComponent<enemyHealthController>().damageEnemy(dmgAmount*3);
         }
         if(other.gameObject.tag == "obstacles"){
            Destroy(gameObject);
        }
        Instantiate(impactEffect,transform.position+(transform.forward*(-moveSpeed*Time.deltaTime)),transform.rotation);
        Destroy(gameObject);
    }
}
