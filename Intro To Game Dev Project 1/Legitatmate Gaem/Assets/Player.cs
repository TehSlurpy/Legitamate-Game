using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject ourSword;

	public float moveSpeed = 10f;


	public bool onGround;
	public bool running;


	private Transform _transform;
	private Rigidbody2D _rigidbody;



		
		



	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 currentPos = transform.position;
		if (Input.GetKey (KeyCode.UpArrow)) {
			currentPos.y += moveSpeed * Time.deltaTime;
			onGround = false;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			currentPos.x += moveSpeed * Time.deltaTime;
		
		}
	
		if (Input.GetKey (KeyCode.LeftArrow)) {
			currentPos.x -= moveSpeed * Time.deltaTime;
		}
		transform.position = currentPos;

	}


	void OnCollisionEnter2D(){
		onGround = true;
	}

}