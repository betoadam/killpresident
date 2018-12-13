using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreparaTiro : MonoBehaviour {

	// Use this for initialization
	public GameObject Atirar;
	private AudioClip ac;
	public AudioSource tiro;

	// Update is called once per frame
	private void Start() {
	}
	public void SelectMira(){
		Atirar.gameObject.SetActive(true);
	}
	public void DesativaMira(){
		Atirar.gameObject.SetActive(false);
	}
	public void AcertouMiseravi(){
		tiro.Play();
		SceneManager.LoadScene("ShotScene");
	}
}
