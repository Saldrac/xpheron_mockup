using UnityEngine;
using System.Collections;

public class InteractionAgent : MonoBehaviour {

	//keep public
	public float activationTime;

	//to hide
	public bool isSelected = false;

	//to set private
	public float activationTimer= 0f;

	void Update (){
		if ( isSelected){
			activationTimer += Time.deltaTime;

			if (activationTimer >= activationTime)
				MakeActions();
		}
	}


	public void Select (){
		isSelected = true;
	}

	public void Unselect (){
		isSelected = false;
		activationTimer = 0f;
	}

	void MakeActions (){
		Debug.Log (transform.name + " acting");
	}
}
