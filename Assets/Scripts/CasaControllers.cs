using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CasaControllers : MonoBehaviour {

	// Use this for initialization
	public GameObject porta;
	public bool abrePorta=false;
	public AudioSource key_sound;
	public AudioSource door_sound;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}
	public void SelectObjects(Transform wayPoint){
		if (wayPoint.gameObject.name == "car_key"){
			Destroy(wayPoint.gameObject);
			key_sound.Play();
			porta.GetComponent<Collider>().enabled=true;
		}
		if (wayPoint.gameObject.name == "Porta"){
			if (abrePorta){
				door_sound.Play();
				SceneManager.LoadScene("CutScene");
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
