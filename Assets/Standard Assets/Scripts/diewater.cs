using UnityEngine;
using System.Collections;

public class diewater : MonoBehaviour {

	GameData gamedata;

	void Start(){
		gamedata = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameData>();

	}
	void OnCollisionEnter(Collision other){
		gamedata.respawn();
	}

}
