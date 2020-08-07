using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class BallController : MonoBehaviour {
	private Rigidbody2D rb;
	private Collider2D coli2d;
	private SpriteRenderer sRender;
	public Transform groundChecker;
	public LayerMask groundLayers;

	private float initGravity;

	//jump
	private bool airJumpAllowed = false;
	public int inAirJumpLimit = 1;

	//movement
	public float walkSpeed = 6.0f;
	public float movementSpeed = 3.0f;
	public float jumpHeight = 3.0f;
	int jumpNumber;

	//shoot
	public GameObject leftBullet, rightBullet;
	Transform firePosLeft, firePosRight;

	//dash

	private float initDashTime;
	private bool allowDash;
	public float xAirborneFactor=0.8f;
	[Range(1.0f,5.0f)]
	public float xAirDashFactor=2.0f;
	[Range(0.0f,3.0f)]

	public float airDashDuration = 0.5f;
	bool isLeft;

	void Awake(){
		rb = GetComponent<Rigidbody2D>();
		sRender = GetComponent<SpriteRenderer>();
		coli2d = GetComponent<Collider2D>();

	}
	void Start(){
		abortDash();
		initGravity = rb.gravityScale;
		jumpNumber = 0;
		airJumpAllowed = true;

		firePosLeft = transform.Find("firePosLeft");
		firePosRight= transform.Find("firePosRight");

	}

	void Update () {
		
		int collDir=isCollideHorizontally();
		Vector2 velo=rb.velocity;
		bool grounded=isGrounded();
		Physics.gravity = new Vector3(0,-1.0f,0);
		
		float h;
		
		if(CrossPlatformInputManager.GetButton("Left") || Input.GetKey(KeyCode.A)){
			h = -1.0f;
			isLeft = true;
		}else if(CrossPlatformInputManager.GetButton("Right")|| Input.GetKey(KeyCode.D)){
			h = 1.0f;
			isLeft = false;
		}else{
			h = 0f;
		}


		float xSpeedFactor=0;
		float dir=Mathf.Sign(h);
		if(grounded) {
			airJumpAllowed=true;
			jumpNumber=0;
		}
		else {
			rb.gravityScale=initGravity;
		}
		if((CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space)) && jumpNumber<=inAirJumpLimit) {
			if(grounded||(airJumpAllowed && collDir==0) ) {
				allowDash=true;
				abortDash();
				velo.y=jumpVelocity();
				jumpNumber=jumpNumber+1;
			}

		}
		if(CrossPlatformInputManager.GetButtonDown("Dash") || Input.GetKeyDown(KeyCode.LeftShift)) {
			if(grounded){
				if(isLeft ||!isLeft){
					allowDash = true;
					Debug.Log(isLeft);
				}
			}
			if(!isAirDashing() && allowDash) {
				Debug.Log("Dashing");
				allowDash=false;
				initDashTime=Time.time;
			}
		}
		if(CrossPlatformInputManager.GetButtonDown("Shoot")||Input.GetKeyDown(KeyCode.CapsLock)){
			//Fire();
			if(isLeft){
				Instantiate(leftBullet, firePosLeft.position, Quaternion.identity);
			}else if(!isLeft){
				Instantiate(rightBullet, firePosRight.position, Quaternion.identity);
			}
		}
		else {
			movementSpeed=walkSpeed;
		}
		if(collDir==dir) {
			xSpeedFactor=0;
			abortDash();
		}
		if(dir==-1) {
			sRender.flipX=true;
		}
		else if(dir==1 && h!=0) {
			sRender.flipX=false;
		}
		if(isAirDashing()) {
			float dashDir = (sRender.flipX) ? -1 : 1;
			xSpeedFactor=xAirDashFactor * dashDir;
			rb.constraints=RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
		}
		else {
			rb.constraints=RigidbodyConstraints2D.FreezeRotation;
			if(grounded)
				xSpeedFactor=h;
			else xSpeedFactor=h*xAirborneFactor;
		}
		velo.x=xSpeedFactor*movementSpeed;
		rb.velocity=velo;
	}
	private int isCollideHorizontally() {
		Bounds bounds=coli2d.bounds;
		Vector2 leftPoint=new Vector2(bounds.min.x-0.01f,
		bounds.min.y+0.01f);
		Collider2D hit = Physics2D.OverlapCircle(leftPoint,0.01f,groundLayers);
		if(hit) return -1;
		Vector2 rightPoint=new Vector2(bounds.max.x+0.01f,
		bounds.min.y+0.01f);
		hit=Physics2D.OverlapCircle(rightPoint,0.01f,groundLayers);
		if(hit) return 1;
		return 0;
	}
	private void abortDash() {
		initDashTime=-(airDashDuration+0.1f);
	}
	private bool isAirDashing() {
		return
			initDashTime<=Time.time&&initDashTime+airDashDuration>=Time.time;
	}
	private bool isGrounded(){ 
		Collider2D hit = Physics2D.OverlapCircle(
			groundChecker.position,0.2f,groundLayers);
		if(hit!=null) {
			return true;
		}
		return false;
	}
	private float jumpVelocity() {
		return Mathf.Sqrt(2*Mathf.Abs(Physics2D.gravity.y)*rb.gravityScale*jumpHeight);
	}

	void Fire(){
		Instantiate(leftBullet, firePosLeft.position, Quaternion.identity);
		Instantiate(rightBullet, firePosRight.position, Quaternion.identity);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name.Equals ("ground-fly-combined-1"))
			this.transform.parent = col.transform;
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.name.Equals ("ground-fly-combined-1"))
			this.transform.parent = null;
	}
}
