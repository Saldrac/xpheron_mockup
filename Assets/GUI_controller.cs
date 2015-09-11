using UnityEngine;
using System.Collections;

public class GUI_controller : MonoBehaviour {
	private bool pause = false;
	public GameObject maincanvas;
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton9)){
			pause = !pause;
			if(pause){
				GameObject.FindGameObjectWithTag("Player").GetComponent<Submarine_controller>().enabled = false;
				Time.timeScale = 0.0f;
				maincanvas.SetActive(true);
			}
			else{
				GameObject.FindGameObjectWithTag("Player").GetComponent<Submarine_controller>().enabled = true;
				Time.timeScale = 1.0f;
				maincanvas.SetActive(false);
			}
		}
	}
}
