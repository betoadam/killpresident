using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void NewGame(Transform wayPoint){
		SceneManager.LoadScene("Casa");	
	}
	public void Menu(Transform wayPoint){
		SceneManager.LoadScene("Menu");	
	}
}
