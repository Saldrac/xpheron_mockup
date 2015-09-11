using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Engines{
	
	public float thrust_force;
	public float sideshift_force;
	public float brake_force;
	public float max_velocity;
	public float acceleration_time;
	public float friction;

}

[Serializable]
public class S_sounds{
	public bool can_play;
	public GameObject Hit_sound;
	public AudioSource sound_engine1;
	public AudioSource sound_engine2;
}

[Serializable]
public class S_weapons{
	public GameObject laser_anchor;
	public Transform torpedo_anchor;
	public GameObject torpedo;
	public float torpedo_cd;
	public float torpedo_speed;
	public bool can_torpedo;
}

[Serializable]
public class S_status{
	public int max_energy;
	public int energy;

	public int max_shield;
	public int shield;


	public int max_torpedoes;
	public int torpedoes;

	public int RP;
}

public class Submarine_controller : MonoBehaviour {
	public Engines engines;
	public S_sounds s_sounds;
	public S_weapons s_weapons;
	public S_status s_status;


	void Start(){
		s_sounds.can_play = true;
		engines.acceleration_time = 0;
		s_weapons.can_torpedo = true;

	}
	

	void Update(){

		//TODO If jitter appears, change. Get key here, process in fixedupdate
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.JoystickButton7)){
			Process_input(KeyCode.W);
			engines.acceleration_time = Mathf.Clamp(engines.acceleration_time + Time.deltaTime,0,1.57f);
		}
		else{
			engines.acceleration_time = 0;
		}
		if(Input.GetKey(KeyCode.A) || Input.GetAxis("RX") == -1)
			Process_input(KeyCode.A);
		if(Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.JoystickButton6))
			Process_input(KeyCode.S);
		if(Input.GetKey(KeyCode.D) || Input.GetAxis("RX") == 1)
			Process_input(KeyCode.D);
		if(Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.JoystickButton0)){
			s_weapons.laser_anchor.SetActive(true);
		}
		if(Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.JoystickButton0)){
			s_weapons.laser_anchor.GetComponentInChildren<ParticleSystem>().Clear();
			s_weapons.laser_anchor.SetActive(false);
		}
		if(Input.GetKey(KeyCode.Mouse1) || Input.GetKey(KeyCode.JoystickButton1)){
			if(s_weapons.can_torpedo){
				GameObject n_torpedo;
				n_torpedo =(GameObject) Instantiate(s_weapons.torpedo,s_weapons.torpedo_anchor.position,s_weapons.torpedo_anchor.rotation);
				n_torpedo.GetComponent<Rigidbody>().AddForce(n_torpedo.transform.forward * s_weapons.torpedo_speed,ForceMode.Impulse);
				GameObject.Destroy(n_torpedo,2);
				s_weapons.can_torpedo = false;
				StartCoroutine(UnlockTorpedo());
			}

		}
		s_sounds.sound_engine1.volume = s_sounds.sound_engine2.volume = (GetComponent<Rigidbody>().velocity.magnitude/engines.max_velocity);

	}

	void FixedUpdate(){
		//We do this here cause the jitter
		Friction();
	}
	

	void OnCollisionEnter(Collision col){
		if(s_sounds.can_play){
			s_sounds.can_play = false;
			GameObject hit_sound = Instantiate(s_sounds.Hit_sound);
			ContactPoint contact = col.contacts[0];
			hit_sound.transform.position = contact.point;
			hit_sound.transform.SetParent(transform);
			hit_sound.GetComponent<AudioSource>().volume =col.relativeVelocity.magnitude/engines.max_velocity;
			DestroyObject(hit_sound,1);
			StartCoroutine(UnlockAfter(2.0f));

		}
	}

	public IEnumerator UnlockTorpedo(){
		yield return new WaitForSeconds(s_weapons.torpedo_cd);
		s_weapons.can_torpedo = true;
	}
	public IEnumerator UnlockAfter(float delay){
		yield return new WaitForSeconds(delay);
		s_sounds.can_play = true;
	}

	void Process_input(KeyCode key){

		//You can control it but the acceleration is too high. Hardcode?
		switch(key){
			case KeyCode.W:
				GetComponent<Rigidbody>().AddForce(transform.forward * engines.thrust_force * Mathf.Sin(engines.acceleration_time), ForceMode.VelocityChange);
				Clip_velocity();
				break;


			case KeyCode.A:
				GetComponent<Rigidbody>().AddForce(transform.right * (-engines.sideshift_force), ForceMode.VelocityChange);
				Clip_velocity();
				break;

			case KeyCode.D:
				GetComponent<Rigidbody>().AddForce(transform.right * engines.sideshift_force, ForceMode.VelocityChange);
				Clip_velocity();
				break;

			case KeyCode.S:
				Progressive_Brake();
				break;

		}
	}

	void Progressive_Brake(){
			GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity * -engines.brake_force, ForceMode.Acceleration);
	}

	void Clip_velocity(){
		GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity,engines.max_velocity);
		
	}
	void Friction(){
		if(GetComponent<Rigidbody>().velocity.magnitude>0.1)
			GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity * -engines.friction, ForceMode.Acceleration);
		else{
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
	}
}