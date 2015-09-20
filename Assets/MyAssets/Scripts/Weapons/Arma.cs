using UnityEngine;
using System.Collections;

public class Arma : MonoBehaviour {

	public int maxMunicion;
	public int municion;
	public Proyectil proyectil;
	public Transform origenProyectil;
	public GameObject laserReference;

	bool laserActive = false;


	public virtual void Update (){
		//Debug.Log (Input.GetMouseButton(0));
		//Debug.Log ("on arma update");

		//Debug.Log (Input.GetMouseButton(0));
		if (Input.GetMouseButtonDown(1)){
			Debug.Log("Pressed right click.");
			//laserActive = !laserActive;
			//armas[armaEquipada].GetComponent<Arma>().laserReference.SetActive(laserActive);
			LaserAction();
			
		}
	}

	public void Disparar (){
		if (municion > 0 ){
			GameObject p = Instantiate (proyectil, origenProyectil.position, origenProyectil.rotation) as GameObject;
			municion --;
		}

	}

	public void Recargar (int cantidad){
		municion += cantidad;
		if (municion >= maxMunicion)
			municion = maxMunicion;
	}

	public void LaserAction(){
		laserActive = !laserActive;
		laserReference.SetActive(laserActive);
	}
}
