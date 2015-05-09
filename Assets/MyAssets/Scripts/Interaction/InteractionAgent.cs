﻿using UnityEngine;
using System.Collections;
//1-isSelected && !acting --> the agent is marked but still not activate the target flag
//2-InitAction --> when the timer ends the agent activate the target's flag and becomes acting (to perform inner animations
//--!readyToAct to avoid further activations
//3-acting && readyToAct-> to call the target object 'init process' (only once)
//4-acting -> to perform inner actions (MakeActions)


public class InteractionAgent : MonoBehaviour {

	//keep public
	public float activationTime = 2f;

	//to hide
	public bool isSelected = false;
	public bool acting = false;
	public bool readyToAct = true;
	//to set private
	public float activationTimer= 0f;


	//for temporary use
	public Color stdColor;
	public Color selectedColor;
	public Renderer rend;

	void Start (){
		rend = GetComponent<Renderer>();
		rend.material.color = stdColor;
	}

	void Update (){


		if ( isSelected && !acting && readyToAct){
			activationTimer += Time.deltaTime;
			rend.material.color = selectedColor;
			if (activationTimer >= activationTime){
				acting = true;
				activationTimer = 0f;
			}
		} else
			rend.material.color = stdColor;

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
	 
	public virtual void MakeActions (){

		//this is for the 'while elevator is moving do something and stop when elevator stops'
		Debug.Log (transform.name + " acting from base interaction agent");
		acting = false;
		//EndAction ();

	}


}
