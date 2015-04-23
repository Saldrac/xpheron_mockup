using UnityEngine;
using System.Collections;

public class StaticPlatform : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		Debug.Log ("hit on platform");
		if(other.gameObject.tag == "Player"){


			other.transform.parent = this.transform;
		}
		
	}
	
	void OnCollisionExit(Collision other){
		if(other.gameObject.tag == "Player"){
			other.transform.parent = null;
		}
	}
}
