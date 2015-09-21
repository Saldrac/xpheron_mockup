using UnityEngine;
using System.Collections;

public class RayWeapon : Arma {

	public GameObject emitter;
	public GameObject target;
	public GameObject laserHitPoint;

	public void Start(){
		emitter.SetActive (false);
	}

	public override void Update (){
		base.Update();
		//Debug.Log ("on ray update");
//		Debug.Log (Input.GetMouseButtonDown(0));

		if (Input.GetMouseButton(0) && municion > 0 && laserActive){
			Debug.Log ("emmiter active");
			target.transform.position = laserHitPoint.transform.position;
			emitter.SetActive (true);
			//laserReference.SetActive (false);
		} else{
			emitter.SetActive (false);
			//laserReference.SetActive (laserActive);
		}

/*
		RaycastHit hit;
	
		Debug.DrawRay (emitter.transform.position, emitter.transform.forward*100, Color.red);
		Physics.Raycast (emitter.transform.position, emitter.transform.forward, out hit, 100);
		
		if (hit.transform != null){
			//currentAgent = hit.transform.GetComponent<InteractionAgent>();
			target.transform.position = hit.transform.position;
			
		} else{
			//currentAgent = null;
		}
*/
	}

	public override void Disparar (){
	}

}
