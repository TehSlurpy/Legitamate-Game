using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject ourSword;

	public float moveSpeed = 10f;

	public float swordSwingTime = 1f;

	public float swordSwingCounter = 0;

	public bool onGround;
	public bool running;


	private Transform _transform;
	private Rigidbody2D _rigidbody;

	SpriteRenderer mySpriteRenderer; 
	Animator anim;


		
		
		



	public Vector2 swingPosition1 = new Vector2(1.2f, 1.01f);
	public Vector2 swingPosition2 = new Vector2(1.31f, 0.01f);
	public Vector2 swingPosition3 = new Vector2(1.32f, -1f);

	public float swingAngle1 = 40.625f;
	public float swingAngle2 = 0f;
	public float swingAngle3 = -35.803f;


	// Use this for initialization
	void Start () {
		
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 currentPos = transform.position;
		if (Input.GetKey (KeyCode.UpArrow)) {
			currentPos.y += moveSpeed * Time.deltaTime;
			anim.Play ("jump");
			onGround = false;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			currentPos.x += moveSpeed * Time.deltaTime;
			mySpriteRenderer.flipX = false;
			anim.Play ("run");
		}
	
		if (Input.GetKey (KeyCode.LeftArrow)) {
			currentPos.x -= moveSpeed * Time.deltaTime;
			mySpriteRenderer.flipX = true;	
			anim.Play ("run");
		

		}
		transform.position = currentPos;


		


		if (swordSwingCounter > 0) {
			// Deal with the timer later.
			if (swordSwingCounter > (0.66f * swordSwingTime)) {
				ourSword.transform.localPosition = swingPosition1;
				ourSword.transform.localRotation = Quaternion.Euler (0, 0, swingAngle1);
			} else if (swordSwingCounter > (0.33f * swordSwingTime)) {
				ourSword.transform.localPosition = swingPosition2;
				ourSword.transform.localRotation = Quaternion.Euler (0, 0, swingAngle2);
			} else {
				ourSword.transform.localPosition = swingPosition3;
				ourSword.transform.localRotation = Quaternion.Euler (0, 0, swingAngle3);
			}


			swordSwingCounter -= Time.deltaTime;
			if (swordSwingCounter <= 0) {
				ourSword.SetActive (false);
			}
		} else {
			
			if (Input.GetKeyDown (KeyCode.Space)) {
				ourSword.SetActive (true);
				swordSwingCounter = swordSwingTime;
				ourSword.transform.localPosition = swingPosition1;
				ourSword.transform.localRotation = Quaternion.Euler (0, 0, swingAngle1);
				anim.Play ("slash");

			}
			if (onGround == false && Input.GetKeyDown (KeyCode.Space)) {

				anim.Play ("jumpingslash");
				 
			}
	
			if (transform.position.y <= -67) {
				Application.LoadLevel ("GameOverScreen");
					
			}



		}
	}
	void OnCollisionEnter2D(){
		onGround = true;
	}
}
