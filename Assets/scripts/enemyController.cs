using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    //its better to use instance of player instead of player directly

    [SerializeField] GameObject player;
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] bool chasing;
    [SerializeField] float distanceToChase = 4f,distanceToLoose = 8f,distanceToStop = 2f;
    private Vector3 targetPoint;
    public NavMeshAgent agent;
    [SerializeField] Vector3 startPos;
    [SerializeField] Quaternion startRotation;

    public float returnTime = 5f ;
    public float chaseCooldownTime;
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate = 0.3F;
    private float nextFire = 0.0F;
    [SerializeField] bool shoot;
    //burst fire 
    public float burstFire ;
    public float burstFireTime = 1f;
    public float burstFireCoolDown;
    public Animator anim; 
    void Start (){
        Invoke("startPosition",0.8f);
        burstFire = burstFireTime;
        chaseCooldownTime = returnTime; 
    }
    void startPosition(){
        startPos = transform.position;
        startPos.y = transform.position.y;
        startRotation.y = transform.rotation.y;
        anim.SetBool("isMoving",false);
    }
    void Update()
    {
        if(playerController.instance.isGameEnded == false)
        {   
            targetPoint = player.transform.position;
            targetPoint.y = transform.position.y;
            if(playerController.instance.gameObject.activeInHierarchy)
            {
                //chasing checker
                if(Vector3.Distance(transform.position ,targetPoint) <= distanceToChase)
                    {
                        chasing = true ;
                        anim.SetBool("isMoving",true);
                        shoot = true;
                    }
                    if(Vector3.Distance(transform.position , targetPoint) > distanceToLoose)
                    {
                        chasing = false;
                        anim.SetBool("isMoving",false);  
                        shoot = false;
                        
                    }
                    if(chasing){
                        if(Vector3.Distance(transform.position,targetPoint)>distanceToStop)
                        {
                            agent.destination = targetPoint;
                            anim.SetBool("isMoving",true);
                            if(shoot){
                                agent.destination = transform.position;    
                                anim.SetBool("isMoving",false);
                            }
                        }

                        else 
                        {
                            agent.destination = transform.position;
                            anim.SetBool("isMoving",false);
                            shoot = false;
                        }
                    
                    }
                
                    if(chasing == false){
                        if(chaseCooldownTime>0 && transform.position != startPos)
                        {   
                            chaseCooldownTime -= Time.deltaTime;
                            if(chaseCooldownTime < returnTime)
                            {
                                anim.SetBool("isMoving",true);
                            }
                            if(chaseCooldownTime <= 0){
                                {
                                    agent.destination = startPos;
                                    chaseCooldownTime = returnTime; 
                                    if(transform.position == startPos)
                                    {
                                        anim.SetBool("isMoving",false);
                                        transform.rotation = startRotation;
                                        shoot = false;
                                        chaseCooldownTime = returnTime;
                                        chasing = false;  
                                    }
                                }  
                            }    
                        }
                    }
                    
                                    
                    
                //handle enemy speed
                agent.speed = moveSpeed;
                //handle burst shots
                if(chasing && burstFire >=0 && shoot)
                burstFire-=Time.deltaTime;
                if(burstFire < 0 && shoot) {
                    burstFireCoolDown += Time.deltaTime;
                    if(burstFireCoolDown < burstFireTime)
                    {
                        agent.destination = targetPoint;
                        anim.SetBool("isMoving",true);
                    }
                    if(burstFireCoolDown >= burstFireTime){
                        burstFire = burstFireTime;
                        burstFireCoolDown = 0f;
                    }
                }
                
                //restrict angles 
                Vector3 targetDir = player.transform.position - transform.position;
                float angle = Vector3.SignedAngle(targetDir , transform.forward , Vector3.up);
                if(Mathf.Abs(angle)<40f&&chasing) shoot = true;
                else shoot = false;
                //handle shooting
                if(Time.time > nextFire&&shoot&&burstFire>=0){
                    nextFire = Time.time + fireRate;
                    firePoint.LookAt(player.transform.position);
                    Instantiate(bullet,firePoint.position,firePoint.rotation);
                    anim.SetTrigger("fireShot");
                } 
            
            }
        }
    }
 
}
