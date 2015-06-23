using UnityEngine;
using System.Collections;

public class EVT_Timer : EventTrigger {
	//keep public
	public float timeToActivate = 5.0f;

	//to set private
	public float activationTimer = 0.0f;
	
	// Update is called once per frame
	void Update () {

		activationTimer += Time.deltaTime;
		if (activationTimer >= timeToActivate){
			triggeredEvent.LaunchEvent();
		}

	}
}
