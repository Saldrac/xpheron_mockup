using UnityEngine;
using System.Collections;

public class EventAgent : MonoBehaviour {


	public virtual void PerformEventActions(){
		Debug.Log ("parent agent event " + transform.name + " launched");
	}
}
