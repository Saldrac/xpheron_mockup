using UnityEngine;
using System.Collections;

public class EVA_ActivateHolodeck : EventAgent {

	public Animator holodeckAnimator;

	public override void PerformEventActions ()
	{
		holodeckAnimator.SetBool ("Activate",true);
		holodeckAnimator.SetBool ("Deactivate",false);
		//Debug.Log ("inicializando holodeck");
	}
}
