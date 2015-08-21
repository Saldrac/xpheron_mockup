using UnityEngine;
using System.Collections;

public class Event : MonoBehaviour {
	//keep public
	public GameObject [] objectsToEnable;

	public GameObject [] objectsToDisable;

	public EventAgent [] eventAgents;



	public float delaytimer;

	public int totalActions;

	public bool oneUseOnly = true;
	public int remainingUses =0;


	public void Start(){

	}


	public void LaunchEvent(){
		//perform event
		UpdateObjectsStatus();
		//Debug.Log ("Evento " +transform.name + " lanzado");



		//update control event
		if (oneUseOnly){
			FreezeEvent();
			return;
		}

		remainingUses --;
		if (remainingUses <= 0){

			FreezeEvent ();

		}  

		Debug.Log ("Event launched. Remaining uses " + remainingUses);
	}

	private void UpdateObjectsStatus(){
		if (objectsToEnable != null){
			for (int i =0; i < objectsToEnable.Length; i ++){
				objectsToEnable[i].SetActive(true);
			}
		}

		if (objectsToDisable != null){
			for (int i = 0; i < objectsToDisable.Length; i++){
				objectsToDisable[i].SetActive (false);
			}
		}

		if (eventAgents != null){
			for (int i = 0; i < eventAgents.Length; i++){
				eventAgents[i].enabled= true;

				eventAgents[i].PerformEventActions();
				//EVA_IncomingTransmission tmp = (EVA_IncomingTransmission)  eventAgents[i];//.PerformEventActions();
				//tmp.PerformEventActions();

			}
		}


	}


	void FreezeEvent (){
		//transform.gameObject.SetActive (false);

	}
}
