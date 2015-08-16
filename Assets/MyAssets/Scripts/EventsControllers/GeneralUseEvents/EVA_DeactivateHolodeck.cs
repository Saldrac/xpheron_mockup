using UnityEngine;
using System.Collections;

public class EVA_DeactivateHolodeck : EventAgent {
	//keep public
	public Animator holodeckAnimator;
	public bool desactivando = false;
	public GameObject virtualScene;

	//set private
	public bool finished = false;
	public float turnOffDelay = 3.0f;
	public float turnOffTimer;

	public  void Update (){
		if (desactivando)
			turnOffTimer += Time.deltaTime;

		if (turnOffTimer >= turnOffDelay){
			virtualScene.SetActive (false);
		}

	}
	public override void PerformEventActions ()
	{
		desactivando = true;
		holodeckAnimator.SetBool ("Activate",false);
		holodeckAnimator.SetBool ("Deactivate",true);
	}
}
