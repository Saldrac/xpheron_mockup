using UnityEngine;
using System.Collections;

public class TorpedoBehaviour : MonoBehaviour {
	public GameObject explosion;

	void OnCollisionEnter(Collision col){
		Destroy(GetComponentInChildren<MeshFilter>());
		Destroy(GetComponentInChildren<MeshRenderer>());
		Destroy(GetComponent<CapsuleCollider>());
		GameObject.Find("Torpedo_particles").GetComponent<ParticleSystem>().Clear();
		foreach(ParticleSystem particles in GetComponentsInChildren<ParticleSystem>()){
			particles.enableEmission = false;
		}
		GameObject.Destroy(gameObject,5);
		GameObject n_explosion = (GameObject)Instantiate(explosion,transform.position,transform.rotation);
		Destroy(n_explosion,5);
	}
}
