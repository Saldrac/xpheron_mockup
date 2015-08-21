using UnityEngine;
using System.Collections;

public class EVA_DeactivateHolodeck : EventAgent {
	//keep public
	public Animator holodeckAnimator;

	//public GameObject virtualScene;


	//set private



	public override void PerformEventActions ()
	{
		desactivando = true;
		holodeckAnimator.SetBool ("Activate",false);
		holodeckAnimator.SetBool ("Deactivate",true);
	}
}
