using UnityEngine;
using System.Collections;

public class MissileWeapon : Arma {
	public Proyectil proyectil;
	public Transform origenProyectil;


	// Use this for initialization

	public override void Update (){
		base.Update();
		Debug.Log ("-->"+ municion);
		//Debug.Log ("on ray update");
		//		Debug.Log (Input.GetMouseButtonDown(0));
		
		if (Input.GetMouseButtonDown(0) && municion > 0){
			Disparar ();
		}

	}

	public override void Disparar (){

		Debug.Log ("disparo desde missileweapon");
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
	


}
