using UnityEngine;
using System.Collections;

public class ElevatorController : InteractionAgent {

	//references to other elements (keep public)
	public GameObject elevatorPlatform;
	public GameObject thisControlTarget;
	public float speed = 1f;

	//for control the elevator group
	public ControllersHolder controllersHolder;


	public override void Start (){
		base.Start ();
		controllersHolder = transform.parent.parent.parent.GetComponent <ControllersHolder>();
		//Debug.Log ("Done");
	}

	//make one single displacement step and check if on target
    public override void MakeActions (){
		float step = speed * Time.deltaTime;
		elevatorPlatform.transform.position = Vector3.MoveTowards(elevatorPlatform.transform.position, thisControlTarget.transform.position,step);

		if (elevatorPlatform.transform.position == thisControlTarget.transform.position)
			EndAction ();

	}


	public override void InitAction (){
		controllersHolder.SetAllAsInactive();
		base.InitAction();

	}


	/*
	void Update (){
		base.Update();

		if (!moving)
			return;

		Move ();

		if (elevatorPlatform.transform.position =thisControlTarget.transform.position)
			StopMovement ();
		//make movement
	}


	void Move(){

	}

	void StopMovement(){
		moving = false;
		EndAction();
	}
*/

}
