using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneScript : MonoBehaviour {

	void Start () {
		StartCoroutine(spawn());
	}

	IEnumerator spawn(){
        yield return new WaitForSeconds(13.5f);
				SceneManager.LoadScene("Cidade");	
    }
}
