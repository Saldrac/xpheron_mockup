//este script es para pruebas. Idealmente esta funcionalidad estara incluida en el sistema de gestion de eventos
//y el 'cameraAutoTracking' (la funcionalidad que ofrece este script) heredara de la clase base 'evento'


//devuelve el control al fps controller
using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;


public class AutoCameraMotionController : MonoBehaviour {
	public GameObject autoCamera;
	public GameObject autoCameraTarget;
	public GameObject fpsController;

	public float stopDistance = 0.5f;

	public float timer = 5;
	bool fadeIn = false;


	void Awake (){
		fpsController.GetComponent<RigidbodyFirstPersonController>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
/*
		if (timer > 0)
			return;
*/
		timer -= Time.deltaTime;

		if (Vector3.Distance (autoCamera.transform.position,autoCameraTarget.transform.position)<stopDistance){
			//fade out auto camera
			//fade in fpscontroller camera
			fadeIn = true;
		}

		if (fadeIn){
			//enable fpsController
			//disable this
			fpsController.GetComponent<RigidbodyFirstPersonController>().enabled = true;
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
