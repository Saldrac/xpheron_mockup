using UnityEngine;
using System.Collections;

public class Moving_platform : MonoBehaviour {
	public int radius;
	public float speed;
	private float moving;
	private float original;
	public enum option{X_axis, Y_axis, Z_axis};
	public option mode; //x axis= 1; y axis= 2; z axis= 3;
	void Start(){
		switch (mode){
		case option.X_axis:
			original = transform.position.x;
			break;
		case option.Y_axis:
			original = transform.position.y;
			break;
		case option.Z_axis:
			original = transform.position.z;
			break;

		}
	}
	
	// Update is called once per frame
	void Update () {
		moving = original + Mathf.PingPong(Time.time * speed, radius);

		switch (mode){
		case option.X_axis:
			transform.position = new Vector3(moving, transform.position.y, transform.position.z);
			break;
		case option.Y_axis:
			transform.position = new Vector3(transform.position.x, moving, transform.position.z);
			break;
		case option.Z_axis:
			transform.position = new Vector3(transform.position.x, transform.position.y, moving);
			break;
			
		}

	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			other.transform.parent = this.transform;
		}

	}

	void OnCollisionExit(Collision other){
		if(other.gameObject.tag == "Player"){
			other.transform.parent = null;
		}
	}
}
