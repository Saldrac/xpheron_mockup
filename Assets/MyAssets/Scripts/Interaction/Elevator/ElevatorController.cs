using UnityEngine;
using System.Collections;

public class ElevatorController : InteractionAgent {

	//references to other elements (keep public)

	public GameObject elevator;
	public GameObject thisControlTarget;


    public override void MakeActions (){
		Debug.Log ("make actions from elevator controller");
		elevator.transform.position = thisControlTarget.transform.position;
	}


}
