using UnityEngine;
using System.Collections;

public class Proyectil : MonoBehaviour {
	public float speed = 1.0f;
	public float lifeTime = 10;
	void Update (){
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
		Destroy (gameObject, lifeTime);

	}

}
