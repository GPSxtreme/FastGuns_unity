using UnityEngine;

public class playerController : MonoBehaviour
{   
    public static playerController instance;
    public float moveSpeed,gravityModifier,jumpPower,runSpeed = 20f;
    public CharacterController charCon;
    private Vector3 moveInput;
    public Transform camTrans,groundCheckPoint;
    public LayerMask groundLayer;
    public float mouseSens;
    public bool invertX , invertY;
    private bool canJump,canDblJump,isSprinting;
    public Animator anim;
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate = 0.2F;
    private float nextFire = 0.0F;
    
    void Awake (){
        instance =  this ;
    }
    void Update()
    {   //store y velocity 
        float yStore = moveInput.y;
        Vector3 verticalMove = transform.forward*Input.GetAxis("Vertical");
        Vector3 horizontalMove = transform.right*Input.GetAxis("Horizontal");
        
        moveInput = verticalMove+horizontalMove;
        moveInput.Normalize();
        //handle sprint 
        if(Input.GetKey(KeyCode.LeftShift)){
            moveInput = moveInput * runSpeed;
           
           
        }else{
            moveInput = moveInput * moveSpeed;
           
        }
       
        moveInput.y = yStore;
        moveInput.y += Physics.gravity.y*gravityModifier*Time.deltaTime;

        if(charCon.isGrounded){
            moveInput.y = Physics.gravity.y*gravityModifier*Time.deltaTime;
        }
        
        canJump = Physics.OverlapSphere(groundCheckPoint.position,0.15f,groundLayer).Length>0;
        //double jump
        if(canJump){
            canDblJump = false;
        }
        //handle jumping 
        if(Input.GetKey(KeyCode.Space)&&canJump){
            moveInput.y = jumpPower; 
            canDblJump = true;
        }
        //handle double jump
        if(canDblJump && Input.GetKeyDown(KeyCode.Space)){
            moveInput.y = jumpPower;
            canDblJump = false;
        }
        
        //append all x,y,z values to the character controller
        charCon.Move(moveInput*Time.deltaTime);
       

        //control camera rotation
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y"))*mouseSens;

        if(invertX){
            mouseInput.x = -mouseInput.x;
        }
        
         if(invertY){
            mouseInput.y = -mouseInput.y;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y+mouseInput.x,transform.rotation.eulerAngles.z);

        camTrans.rotation = Quaternion.Euler(camTrans.rotation.eulerAngles + new Vector3( -mouseInput.y,0f,0f));

        //handle shooting 
        if(Input.GetMouseButton(0)&& Time.time > nextFire){
            nextFire = Time.time + fireRate;
            
            RaycastHit hit;
            if(Physics.Raycast(camTrans.position,camTrans.forward,out hit,50f))
            {
                if(Vector3.Distance(camTrans.position,hit.point)>2f)
                {
                firePoint.LookAt(hit.point);
                }
            }else {
                firePoint.LookAt(camTrans.position + camTrans.forward*30f);
            }
            
            Instantiate(bullet,firePoint.position,firePoint.rotation);
        }
        
        //handle animations
        anim.SetFloat("moveSpeed",moveInput.magnitude);
        anim.SetBool("onGround",canJump);
    }
}
