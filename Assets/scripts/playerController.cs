using System.Collections.Generic;
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
    public Transform firePoint;
    public gunManager activeGun;
    public int currentGun;
    public List<gunManager> allGuns = new List<gunManager>();
    public List<gunManager> specialGuns = new List<gunManager>();

    public Transform adsPoint,gunHolder;
    private Vector3 gunStartPos;
    public float adsSpeed;
    public GameObject muzzleFlash;
    public AudioSource footStepFast , footStepSlow ;
    public float bounceStrength;
    private bool bounce;
    public bool isGameEnded;
    
    void Awake (){
        instance =  this ;
    }
    void Start(){
        activeGun = allGuns[currentGun];
        activeGun.gameObject.SetActive(true);
        gunStartPos = gunHolder.localPosition;
    }
    void Update()
    {   if(uiController.instance.pauseScreen.activeInHierarchy == false && isGameEnded == false){
         //store y velocity 
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
        //restart game when player falls off map 
        if(transform.position.y < -50){
            gameManager.instance.restartGame();
        }
        //double jump
        if(canJump){
            canDblJump = false;
        }
        //handle jumping 
        if(Input.GetKey(KeyCode.Space)&&canJump){
            moveInput.y = jumpPower; 
            canDblJump = true;
            audioManager.instance.playSfx(15);
        }
        //handle double jump
        if(canDblJump && Input.GetKeyDown(KeyCode.Space)){
            moveInput.y = jumpPower;
            canDblJump = false;
            audioManager.instance.playSfx(15);
        }
        if(bounce){
            bounce = false;
            moveInput.y = bounceStrength;
            canDblJump = true;
        }
        //handle zoom;
        if(Input.GetMouseButtonDown(1)){
            cameraController.instance.zoomIn(activeGun.zoomAmount);
        }
        if(Input.GetMouseButton(1)){
            gunHolder.position = Vector3.MoveTowards(gunHolder.position,adsPoint.position,adsSpeed*Time.deltaTime);
        }else {
            gunHolder.localPosition = Vector3.MoveTowards(gunHolder.localPosition,gunStartPos,adsSpeed*Time.deltaTime);

        }
        if(Input.GetMouseButtonUp(1)){
            cameraController.instance.zoomOut();

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

        muzzleFlash.SetActive(false);
        //handle shooting 
        //single shot
        if(Input.GetMouseButtonDown(0) && activeGun.fireCounter <= 0){
            
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
           fireShot();
        }
        //multi shot
        if(Input.GetMouseButton(0)&& activeGun.canAutoFire){
            if(activeGun.fireCounter <=0 ){
                fireShot();
            }
        }
        if(Input.GetKeyDown(KeyCode.Tab)){
            switchGun();
        }
        //handle animations
        anim.SetFloat("moveSpeed",moveInput.magnitude);
        anim.SetBool("onGround",canJump);
        
        }
    }
    public void fireShot(){
        if(activeGun.currentAmmo >0)
        {
            activeGun.currentAmmo--;
            Instantiate(activeGun.bullet , firePoint.position , firePoint.rotation);
            activeGun.fireCounter = activeGun.fireRate;
            muzzleFlash.SetActive(true);
        }
        
    }  
    public void switchGun(){
        activeGun.gameObject.SetActive(false);
        currentGun++;
        if(currentGun >= allGuns.Count) currentGun = 0;
        activeGun = allGuns[currentGun];
        activeGun.gameObject.SetActive(true);
        firePoint.position = activeGun.firePoint.position;
    }
    public void addGun(string gunToAdd){
        if(specialGuns.Count > 0)
        {
            for(int i=0;i<specialGuns.Count;i++){
                if(specialGuns[i].gunName == gunToAdd){
                    allGuns.Add(specialGuns[i]);
                    specialGuns.RemoveAt(i);
                    i = specialGuns.Count;
                }
            }
        }
    }
    public void playerBounce(float bouncePadStrength){
        bounceStrength = bouncePadStrength;
        bounce = true;
    }
}
