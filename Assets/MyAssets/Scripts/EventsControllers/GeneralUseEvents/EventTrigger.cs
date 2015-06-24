using UnityEngine;
using System.Collections;

public class EventTrigger : MonoBehaviour {

	//to set private
	public Event triggeredEvent;

	// Use this for initialization
	void Start () {
		triggeredEvent = GetComponent <Event>();
	}
	
	// Update is called once per frame
	void Update () {
		triggeredEvent.LaunchEvent();
	}
}
