using UnityEngine;
using System.Collections;

public class SphereDoors : MonoBehaviour {

	public Animator doorTop;
	public Animator doorBottom;
	public BoxCollider trigger;

	//to set private
	public int playersInTheTrigger=0;


	public void Update (){
		if (playersInTheTrigger >= 1){
			doorTop.SetBool("Opening",true);
			doorBottom.SetBool("Opening",true);

		} else{
			doorTop.SetBool("Opening",false);
			doorBottom.SetBool("Opening",false);
		}
	}


	public void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player"){
			playersInTheTrigger ++;
		}
	}

	public void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player"){
			playersInTheTrigger --;
		}
	}
	
}
