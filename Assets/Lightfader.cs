using UnityEngine;
using System.Collections;

public class Lightfader : MonoBehaviour {
	private Light light;
	public float light_decay_rate;


	void Start () {
		light = GetComponent<Light>();
	}
	

	void FixedUpdate () {
		light.intensity -=light_decay_rate;
	}
}
