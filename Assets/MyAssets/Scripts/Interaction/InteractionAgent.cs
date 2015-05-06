using UnityEngine;
using System.Collections;
//1-isSelected && !acting --> the agent is marked but still not activate the target flag
//2-InitAction --> when the timer ends the agent activate the target's flag and becomes acting (to perform inner animations
//--!readyToAct to avoid further activations
//3-acting && readyToAct-> to call the target object 'init process' (only once)
//4-acting -> to perform inner actions (MakeActions)


public class InteractionAgent : MonoBehaviour {

	//keep public
	public float activationTime;

	//to hide
	public bool isSelected = false;
	public bool acting = false;
	public bool readyToAct = true;
	//to set private
	public float activationTimer= 0f;

	void Update (){
		if ( isSelected && !acting){
			activationTimer += Time.deltaTime;

			if (activationTimer >= activationTime){
				acting = true;
				readyToAct = true;
				activationTimer = 0f;
			}
		}

		if (acting && readyToAct) 
			InitAction ();

		if (acting){
			MakeActions ();
		}

	}

	//to be called by the interaciton manager
	public void Select (){
		isSelected = true;
		activationTimer = 0;
	}
	//to be called by the interaciton manager
	public void Unselect (){
		isSelected = false;
		activationTimer = 0f;
	}

	public void EndAction(){
		//to be called by the tartget object once it finished its actions
		readyToAct = true;
		acting = false;
	}

	public void InitAction(){
		acting = true;
		readyToAct = false;
		activationTimer = 0;
		//activate 'acting' flag in the target
	}

	void MakeActions (){

		//this is for the 'while elevator is moving do something and stop when elevator stops'
		Debug.Log (transform.name + " acting");

		//EndAction ();

	}


}
