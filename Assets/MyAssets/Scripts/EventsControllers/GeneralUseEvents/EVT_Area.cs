using UnityEngine;
using System.Collections;

public class EVT_Area : EventTrigger {

	//keep public
	//public Collider triggerArea;

	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter(Collider col){

		triggeredEvent.LaunchEvent();

	}
}
