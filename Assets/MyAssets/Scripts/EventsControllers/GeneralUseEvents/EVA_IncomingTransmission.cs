using UnityEngine;
using System.Collections;

public class EVA_IncomingTransmission : EventAgent {
	//keep public
	public string textMessage;

	//set private
	public AudioSource audioMessage;

	public override void PerformEventActions(){

		audioMessage.Play();
		Debug.Log (transform.name + " message: " + textMessage);
	}

}
