using UnityEngine;
using System.Collections;

public class AquaFriction : MonoBehaviour {
	public Vector3 friction;
	//Force will go from -threshold to +threshold
	public float force_threshold;
	public float period_threshold;
	private float period_seconds;
	private float cd_counter = 0;

	//The forces should be added in fixed update
	void FixedUpdate () {
		if(Time.time > cd_counter){
			period_seconds = Random.Range(0,period_threshold);
			cd_counter  = Time.time + period_seconds;
			recalculate_friction();
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().AddForce(friction, ForceMode.Impulse);
		}
	}


	void recalculate_friction(){
		friction.x = Random.Range(-force_threshold,force_threshold);
		friction.y = Random.Range(-force_threshold,force_threshold);
		friction.z = Random.Range(-force_threshold,force_threshold);
	}

}
