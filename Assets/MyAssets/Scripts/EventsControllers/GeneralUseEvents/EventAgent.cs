using UnityEngine;
using System.Collections;

public class EventAgent : MonoBehaviour {
	/*
	public void Start (){
		//enabled = false;
	}
*/
	/*
	public virtual void Update (){
		//Debug.Log ("update");
	}
*/


	public virtual void PerformEventActions(){
		Debug.Log ("parent agent event " + transform.name + " launched");
	}
}
