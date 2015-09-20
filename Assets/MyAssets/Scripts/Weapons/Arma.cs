using UnityEngine;
using System.Collections;

public class Arma : MonoBehaviour {

	public int maxMunicion;
	public int municion;
	public Proyectil proyectil;
	public Transform origenProyectil;




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
}
