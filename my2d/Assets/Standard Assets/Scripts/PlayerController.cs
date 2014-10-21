using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float JumpForce = 100f;
	public float MoveSpeed = 20f;
	public float WindSpeed = 25f;

	private static bool jumped;
	private static bool anchored;
	private static bool grounded;
	private static bool moved;

	private static Vector3 windforce;
	private static Vector3 characterforce;
	
	void Start () {
		jumped = false;
		moved = false;
		anchored = true;
		grounded = true;
		windforce = BackgroundController.current.normalizedspeed * WindSpeed * Vector3.left;
		characterforce = Vector3.zero;
	}
	void OnCollisionEnter(Collision theCollision)
	{
		if(theCollision.gameObject.name == "Wagons" || theCollision.gameObject.name == "Floor")
		{
			grounded = true;
		}
	}
	void OnCollisionExit(Collision theCollision){
		if(theCollision.gameObject.name == "Wagons" || theCollision.gameObject.name == "Floor")
		{
			grounded = false;
		}
	}
	void Update () {
		if (grounded) {
			if (Input.GetButtonUp ("Jump")) {
				jumped = true;
				moved = false;
				anchored = false;
				Debug.Log ("Jumped!");
			}
			if (Input.GetButtonUp ("Grab")) {
				anchored = true;
				moved = false;
				jumped = false;
				Debug.Log ("Anchored!");
			}
			if (Input.GetButton ("Move")) {
				moved = true;
				anchored = false;
				jumped = false;
				Debug.Log ("Moved...");
			}
		}
	}
	void FixedUpdate () 
	{
		if (jumped) 
		{
			Debug.Log("Jumping...");
			characterforce = BackgroundController.current.normalizedspeed * JumpForce * Vector3.up;
		}
		if (anchored) 
		{
			Debug.Log("Anchoring...");
			characterforce = Vector3.zero;
			//rigidbody.velocity = Vector3.zero;
			//rigidbody.rotation = Quaternion.identity;
		}
		if (moved) 
		{
			Debug.Log("Moving...");
			characterforce = BackgroundController.current.normalizedspeed * MoveSpeed * Vector3.right;
		}
		rigidbody.AddForce(characterforce + windforce);
		jumped = false;
		moved = false;
	}

}
