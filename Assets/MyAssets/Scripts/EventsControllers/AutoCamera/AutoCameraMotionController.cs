//este script es para pruebas. Idealmente esta funcionalidad estara incluida en el sistema de gestion de eventos
//y el 'cameraAutoTracking' (la funcionalidad que ofrece este script) heredara de la clase base 'evento'

using UnityEngine;
using System.Collections;

public class AutoCameraMotionController : MonoBehaviour {
	public GameObject autoCamera;
	public GameObject autoCameraTarget;
	public GameObject fpsController;

	public float stopDistance = 0.5f;
	bool fadeIn = false;

	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (autoCamera.transform.position,autoCameraTarget.transform.position)<stopDistance){
			//fade out auto camera
			//fade in fpscontroller camera
			fadeIn = true;
		}

		if (fadeIn){
			//enable fpsController
			//disable this
			fpsController.SetActive (true);
			autoCamera.transform.parent.gameObject.SetActive(false);
		}

	}

	/*
	void FadeIn(){
//do fade in
//set fadedIn flag = true
	}

*/
}
