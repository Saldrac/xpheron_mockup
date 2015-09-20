using UnityEngine;
using System.Collections;

public class WeaponsManager : MonoBehaviour {

	public GameObject [] armas;
	public int armaEquipada;


	bool laserActive = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("-->" + Input.GetMouseButton(1));



		if (Input.GetMouseButtonDown(1)){
			Debug.Log("Pressed right click.");
			laserActive = !laserActive;
			armas[armaEquipada].GetComponent<Arma>().laserReference.SetActive(laserActive);

		}

	}
}
