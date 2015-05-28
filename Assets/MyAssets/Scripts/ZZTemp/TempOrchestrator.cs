using UnityEngine;
using System.Collections;

public class TempOrchestrator : MonoBehaviour {

	public float timer = 5f;

	public GameObject autoCamera;
	//public GameObject mainFPS;
	// Use this for initialization
	void Start () {

		//set initial status
		autoCamera.SetActive (false);
		//mainFPS.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0 ){
			timer -= Time.deltaTime;
			return;
		}

		//mainFPS.SetActive (true);
		autoCamera.SetActive (true);
		enabled = false;

	}
}
