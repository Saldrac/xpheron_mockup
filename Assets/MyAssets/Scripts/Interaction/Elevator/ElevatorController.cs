using UnityEngine;
using System.Collections;

public class ElevatorController : InteractionAgent {

	//references to other elements (keep public)

	public GameObject elevatorPlatform;
	public GameObject thisControlTarget;


    public override void MakeActions (){
		Debug.Log ("make actions from elevator controller");
		elevatorPlatform.transform.position = thisControlTarget.transform.position;
		EndAction ();
	}


}
