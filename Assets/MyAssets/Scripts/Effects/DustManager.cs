using UnityEngine;
using System.Collections;

public class DustManager : MonoBehaviour {

	public GameObject[] posiciones;
	public ParticleSystem dustEmitter;
	public int currentPosition;
	public float changePositionTime = 10;

	//to set private
	public float generalPurposeTimer= 0;

	void Update () {
		generalPurposeTimer += Time.deltaTime;
		if (generalPurposeTimer>=changePositionTime){
			SetNextEmitter ();
			generalPurposeTimer =0;
		}

	}

	private void SetNextEmitter(){
		Debug.Log ("CAMBIO ");
		int i = Random.Range (0,posiciones.Length - 1);
		dustEmitter.transform.position = posiciones[i].transform.position;
		dustEmitter.Stop();
		dustEmitter.Play ();

	}
}
