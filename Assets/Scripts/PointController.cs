using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour {

	// Use this for initialization
	float duration = 1.0f;
	private float lerp = 1;
	public Renderer rend;
	Color newColor;
	void Start () {
		newColor = new Color(0.3f, 0.4f, 0.6f, 0.05f);
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		lerp = Mathf.PingPong(Time.time, duration) / duration;
		ColorChangerr();
	}
	void ColorChangerr()
     {
		rend.material.color = Color.Lerp(Color.green, newColor, lerp);
		lerp = Mathf.PingPong(Time.time,duration)/duration; 
     }
}
