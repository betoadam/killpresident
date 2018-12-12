using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Virar(Transform wayPoint){
		if (wayPoint.gameObject.name == "car_key"){
			Destroy(wayPoint.gameObject);
			//porta.GetComponent<Collider>().enabled=true;
		}
		if (wayPoint.gameObject.name == "Porta"){
			if (true){
				//SceneManager.LoadScene("Cidade");
			}
		}
		//deve ser
	}
}
