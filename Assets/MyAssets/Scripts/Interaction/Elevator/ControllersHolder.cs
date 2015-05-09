using UnityEngine;
using System.Collections;

public class ControllersHolder : MonoBehaviour {
	//controllers (to set private)
	public ElevatorController [] elevatorControllers;

	public void Start (){

		elevatorControllers = gameObject.transform.parent.GetComponentsInChildren<ElevatorController>();
		Debug.Log ("done");
	}

	public void SetAllAsInactive(){
		foreach (ElevatorController ec in elevatorControllers){
			ec.EndAction();
		}
	}
}
