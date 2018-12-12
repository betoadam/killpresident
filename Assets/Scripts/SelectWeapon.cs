using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWeapon : MonoBehaviour {
	
	public GameObject comprar;
	private Animation anim;
	private AudioClip ac;

	// Update is called once per frame
	private void Start() {
		anim = GetComponent<Animation>();
	}
	public void SelectArma(){
		ac = Resources.Load("gunchoice") as AudioClip;
        AudioSource.PlayClipAtPoint(ac, Vector3.zero);
		anim.Play("shot");
		comprar.gameObject.SetActive(true);
	}
	public void DesativaArma(){
		ac = Resources.Load("gunchoice") as AudioClip;
        AudioSource.PlayClipAtPoint(ac, Vector3.zero);
		anim.Play("voltashot");	
		comprar.gameObject.SetActive(false);
	}
	public void SelectRifle(){
		ac = Resources.Load("gunchoice") as AudioClip;
        AudioSource.PlayClipAtPoint(ac, Vector3.zero);
		anim.Play("rifleshot");
		comprar.gameObject.SetActive(true);
	}
	public void DeactiveRifle(){
		ac = Resources.Load("gunchoice") as AudioClip;
        AudioSource.PlayClipAtPoint(ac, Vector3.zero);
		anim.Play("returnrifle");	
		comprar.gameObject.SetActive(false);
	}
}
