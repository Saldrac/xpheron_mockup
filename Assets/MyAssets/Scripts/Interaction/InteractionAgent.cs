using UnityEngine;
using System.Collections;

public class InteractionAgent : MonoBehaviour {

	//keep public
	public float activationTime;

	//to hide
	public bool isSelected = false;
	public bool acting = false;

	//to set private
	public float activationTimer= 0f;

	void Update (){
		if ( isSelected && !acting){
			activationTimer += Time.deltaTime;

			if (activationTimer >= activationTime){
				InitAction ();
			}
		}

		if (acting) 
			MakeActions ();

	}


	public void Select (){
		isSelected = true;
		activationTimer = 0;
	}

	public void Unselect (){
		isSelected = false;
		activationTimer = 0f;
	}

	public void InitAction(){
		acting = true;
		activationTimer = 0;
	}

	void MakeActions (){
		Debug.Log (transform.name + " acting");

		EndAction ();

	}

	public void EndAction(){
		acting = false;
	}
}
