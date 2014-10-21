using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Rigidbody subject;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position;
	}

	void LateUpdate () {
		transform.position = subject.transform.position + offset;
	}

}
