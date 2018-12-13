using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootSceneController : MonoBehaviour {

	void Start () {
		StartCoroutine(spawn());
	}

	IEnumerator spawn(){
        yield return new WaitForSeconds(9.7f);
				SceneManager.LoadScene("Ganhou");	
    }
}
