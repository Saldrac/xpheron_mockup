using UnityEngine;
using System.Collections;

public class EVT_Area : EventTrigger {

	//keep public
	//public Collider triggerArea;

	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter(Collider col){
		if (permanent || remainingUses > 0){
			triggeredEvent.LaunchEvent();
			remainingUses --;
		}

	}
}
