using UnityEngine;
using System.Collections;

public class InteractorTool : MonoBehaviour {

	public float interactionDistance = 0.5f;
	//public GameObject lastSelected = null;
	public InteractionAgent lastSelected = null;


	//references to other elements in the same prefab
	public Camera playerCamera;


	//to set private
	public InteractionAgent currentAgent;

	void Update() {
		RaycastHit hit;

		Debug.DrawRay (playerCamera.transform.position, playerCamera.transform.forward*interactionDistance, Color.cyan);
		Physics.Raycast (playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance);

		if (hit.transform != null && hit.transform.tag == "InteractiveByRay"){
			currentAgent = hit.transform.GetComponent<InteractionAgent>();

		} else{
			currentAgent = null;
		}


		if ( currentAgent != lastSelected){
			if (currentAgent == null){
				lastSelected.Unselect();
				lastSelected = null;
			} else{
				if (lastSelected != null)
					lastSelected.Unselect ();
				lastSelected = currentAgent;
				lastSelected.Select();
			}


		}

/*
		if (hit.transform != null && hit.transform.tag == "InteractiveByRay"){
			InteractionAgent currentAgent = hit.transform.GetComponent<InteractionAgent>();
			if (currentAgent != lastSelected){
				if (lastSelected != null){
					lastSelected.Unselect();
				}
				lastSelected = currentAgent;
				lastSelected.Select();
				//InteractionAgent interactionAgent = hit.transform.GetComponent<InteractionAgent>();
			}

		
		}
*/
	}
}
