using UnityEngine;
using System.Collections;

public class BaseScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("Start");
	}
	
	// Update is called once per frame
	void Update () {

	}

	public static void LogMe(object message)
	{
		Debug.Log (message);
	}
}
