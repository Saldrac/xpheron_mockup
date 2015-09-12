using UnityEngine;
using System.Collections;

public class EVA_ActivateHolodeck : EventAgent {

	public Animator holodeckAnimator;
	public Animator platformsAnimator;
	public Animator lightEffectAnimation;
	public DustManager dustManager;
	public GameObject platformsSet; //to hide until animate
	public LensFlare lensFlare;
	//to set private
	public float generalTimer;
	public float platformsTime =3;
	public bool waitingForPlatforms = false;

	public float deslumbrarTime = 2;
	public bool deslumbrarHecho = false;
	public void Update(){
		if (!waitingForPlatforms)
			return;

		//las plataformas se activan retardadas respecto a la holodeck
		generalTimer+=Time.deltaTime;
		if (generalTimer >= platformsTime){
			platformsSet.SetActive(true);
			platformsAnimator.SetBool ("Activate", true);
			platformsAnimator.SetBool ("Deactivate",false);
			waitingForPlatforms = false;
		}

		if (!deslumbrarHecho){
			if (generalTimer>= deslumbrarTime){
				dustManager.enabled = true;
				deslumbrarHecho = true;
				lightEffectAnimation.SetBool ("Deslumbrar",true);
				lensFlare.enabled = true;
			}
		}



	}

	public override void PerformEventActions ()
	{
		holodeckAnimator.SetBool ("ActivarHolo",true);
		holodeckAnimator.SetBool ("DesactivarHolo",false);
		platformsSet.SetActive(false);
		waitingForPlatforms = true;


		//Debug.Log ("inicializando holodeck");
	}
}
