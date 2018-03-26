using UnityEngine;
using System.Collections;

public class playerwalk : MonoBehaviour {
	Vector3 startPos;
	public float playerSpeed = 2.5f;
	float jumpSpeed = 250f;
	Animator movement;
	public bool respawn = true;
	bool jump = false;
	float distanceToGround;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
		movement = GetComponent<Animator>();
		distanceToGround = GetComponent<BoxCollider> ().bounds.extents.y;
	}

	public bool IsNotGrounded()
	{
		return Physics.Raycast (transform.position, Vector3.down, distanceToGround + 0.1f);
	}
	// Update is called once per frame
	void Update () {
		movement.SetFloat ("speed", 1f);
		transform.localPosition += transform.forward * playerSpeed * Time.deltaTime;
		if (IsNotGrounded()) {
			movement.SetFloat ("jump", 1f);
		} 
		else {
			movement.SetFloat("jump", 0f);
		}
	}

	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Jump") == true) {
			GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed);
		}
		if (other.gameObject.CompareTag ("Death") == true) {
			transform.position = startPos;
			respawn = true;
		}
	}
}
