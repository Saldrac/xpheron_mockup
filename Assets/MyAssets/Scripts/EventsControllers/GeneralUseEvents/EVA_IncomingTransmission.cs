using UnityEngine;
using System.Collections;

public class EVA_IncomingTransmission : EventAgent {
	//keep public
	public string textMessage;
	public AudioSource audioSource;  //esto deberia ser parte del interfaz... quiza un audioSource 2d general
	public AudioClip initMessage;
	public AudioClip audioMessage;
	public AudioClip  endMessage;
	//public reference to GUIManager

	//set private
	public float mainTimer= 0.0f;
	public bool playEvent = false;
	public bool initPlayed = false;
	public bool messagePlayed = false;
	public bool endPlayed = false;


	void Start (){

	}

	void Update (){

		if (!initPlayed ){
			initPlayed = true;
			audioSource.clip = initMessage;
			audioSource.Play();
		}
		else
		if (!messagePlayed && mainTimer >= initMessage.length){
			messagePlayed = true;
			audioSource.clip = audioMessage;
			audioSource.Play ();
		}
		else
		if (!endPlayed && mainTimer >= initMessage.length + audioMessage.length){
			endPlayed = true;
			audioSource.clip = endMessage;
			audioSource.Play ();

		}
		else
		if (mainTimer >= initMessage.length + audioMessage.length + endMessage.length + 5f){
			enabled = false;

		}



		mainTimer += Time.deltaTime;
	}

	public override void PerformEventActions(){

		//audioMessage.Play();
		Debug.Log (transform.name + " message: " + textMessage);

		//GUIManager.setText = textMessage; o GUIManager.NewMessage (textMessage)
	}




}
