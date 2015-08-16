using UnityEngine;
using System.Collections;

public class EVT_Timer : EventTrigger {
	//keep public
	public float timeToActivate = 5.0f;

	//to set private
	public float activationTimer = 0.0f;
	public bool triggered = false;
	// Update is called once per frame
	void Update () {
		if (remainingUses<=0 && !permanent)
			return;



		activationTimer += Time.deltaTime;
		if (activationTimer >= timeToActivate){
			activationTimer =0;
			remainingUses --;
			triggeredEvent.LaunchEvent();
		}

	}
}
