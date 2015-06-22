using UnityEngine;
using System.Collections;

public class Event : MonoBehaviour {
	public GameObject [] objectsToEnable;
	public GameObject [] objectsToDisable;

	public void Start(){
		LaunchEvent ();
	}


	public void LaunchEvent(){

		UpdateObjectsStatus();
		Debug.Log ("Evento " +transform.name + " lanzado");
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
	}
}
