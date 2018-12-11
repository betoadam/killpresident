using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWeapon : MonoBehaviour {
	
	public GameObject comprar;
	private Animation anim;

	// Update is called once per frame
	private void Start() {
		anim = GetComponent<Animation>();
	}
	public void SelectArma(){
		anim.Play("shot");
		comprar.gameObject.SetActive(true);
	}
	public void DesativaArma(){
		anim.Play("voltashot");	
		comprar.gameObject.SetActive(false);
	}
}
