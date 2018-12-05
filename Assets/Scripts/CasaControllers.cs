using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CasaControllers : MonoBehaviour {

	// Use this for initialization
	public GameObject porta;
	public bool abrePorta=false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}
	public void SelectObjects(Transform wayPoint){
		if (wayPoint.gameObject.name == "car_key"){
			Destroy(wayPoint.gameObject);
			porta.GetComponent<Collider>().enabled=true;
		}
		if (wayPoint.gameObject.name == "Porta"){
			if (abrePorta){
				SceneManager.LoadScene("Cidade");
			}
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("GameController")){
			abrePorta=true;
		}else{
			abrePorta=false;	
		}
	}
}
