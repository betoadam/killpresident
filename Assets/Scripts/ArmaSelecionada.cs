using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArmaSelecionada : MonoBehaviour {

	// Use this for initialization
	static int arma;
	public GameObject shotgun;
	public GameObject sniper;
	private AudioClip ac;
	void Start () {
		Debug.Log(arma.ToString());
		if(SceneManager.GetActiveScene().name=="Cidade"){
			arma = 0;
		}
		if(arma == 1){
			shotgun.gameObject.SetActive(true);	
		}
		if(arma == 2){
			sniper.gameObject.SetActive(true);	
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void pegaShotgun(){
		ac = Resources.Load("gunshop") as AudioClip;
        AudioSource.PlayClipAtPoint(ac, Vector3.zero);
		arma = 1;
		SceneManager.LoadScene("CidadeRetorno");
	}
	public void pegaRifle(){
		ac = Resources.Load("gunshop") as AudioClip;
        AudioSource.PlayClipAtPoint(ac, Vector3.zero);
		arma = 2;
		SceneManager.LoadScene("CidadeRetorno");
	}
}
