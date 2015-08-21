using UnityEngine;
using System.Collections;

public class EventAgent : MonoBehaviour {

	public bool desactivando = false;
	public bool finished = false;
	public float turnOffDelay = 3.0f;
		   float turnOffTimer;
	public GameObject [] objectsToDeactivateWithDelay;
	public GameObject [] objectsToActivateWithDelay;




	public  void Update (){
		if (desactivando )
			turnOffTimer += Time.deltaTime;
		
		if (turnOffTimer >= turnOffDelay){
			//virtualScene.SetActive (false);
			
			foreach (GameObject go in objectsToDeactivateWithDelay){
				go.SetActive  (false);
			}

			foreach (GameObject go in objectsToActivateWithDelay){
				go.SetActive (true);

			}
			
			enabled = false;
			//y self-disable para evitar mas updates
		}
		
	}


	public virtual void PerformEventActions(){
		Debug.Log ("parent agent event " + transform.name + " launched");
	}
}
