using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWalk : MonoBehaviour {

	// Use this for initialization
	public Transform player;
	public float speed;
	private bool isWaling;
	private const int MAX_ANGLE = 90;
	public float threshold;
	public bool freezeY;

	
	// Update is called once per frame
	void Update () {
		isWaling = !isWaling && 
		transform.eulerAngles.x >= threshold && 
		transform.eulerAngles.x <= MAX_ANGLE;	

		if(isWaling){
			Vector3 direcao = transform.TransformDirection(Vector3.forward);
			player.Translate(direcao* speed);
		}
		if(freezeY){
			player.transform.position = new Vector3(
				player.transform.position.x,
				1,
				player.transform.position.z
			);
		}
	}
	public void JumpToPosition(Transform wayPoint){
		player.transform.position = wayPoint.position;
	}
}
