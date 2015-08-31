using UnityEngine;
using System.Collections;

public class EVA_DeactivateHolodeck : EventAgent {
	//keep public
	public Animator holodeckAnimator;
	public GameObject playerHolder;
	public GameObject playerController;
	public DustManager dustManager;


	//set private



	public override void PerformEventActions ()
	{
		desactivando = true;
		holodeckAnimator.SetBool ("Activate",false);
		holodeckAnimator.SetBool ("Deactivate",true);
		playerController.transform.parent = playerHolder.transform.parent;
		dustManager.enabled = false;
	}
}
