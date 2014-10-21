using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	[HideInInspector]
	public float normalizedspeed;

	public float speed = 0.005f;
	public static BackgroundController current;

	float pos = 0f;
	// Use this for initialization
	void Start () {
		current = this;
		normalizedspeed = speed * 1000;
	}

	public void Go()
	{
		pos += speed;
		if (pos > 1.0f)
						pos -= 1.0f;
		if (pos < -1.0f)
						pos += 1.0f;

		renderer.material.mainTextureOffset = new Vector2 (pos, 0);
	}
}
