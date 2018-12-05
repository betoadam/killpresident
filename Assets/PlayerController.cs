using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
	rb = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
		Debug.Log(other);
		if(other.CompareTag("Mato")){
			rb.drag = 0.5f;
		}
		else
		if(other.CompareTag("Asfalto")){
			rb.drag = 0.05f;
		}
		else
		if(other.CompareTag("Subida")){
			rb.angularDrag = 10.0f;
		}
		else
		if(other.CompareTag("SubidaFraca")){
			rb.angularDrag = 0.0f;
		}
		
	}
}
