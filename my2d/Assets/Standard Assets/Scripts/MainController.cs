using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {
	public static MainController current;

	void Start () {
		current = this;
	}
	
	void LateUpdate() {		
		BackgroundController.current.Go();
	}

}
