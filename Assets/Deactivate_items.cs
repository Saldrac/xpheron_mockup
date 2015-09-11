using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Deactivate_items : MonoBehaviour {

	//Toggle between this 2 groups 
	public List<GameObject> items1;
	public List<GameObject> items2;


	void Start(){
		Activate();
	}

	public void Activate(){
		foreach (GameObject item in items1){
			item.SetActive(true);
		}
		foreach (GameObject item in items2){
			item.SetActive(false);
		}
	}

	public void Deactivate(){
		foreach (GameObject item in items1){
			item.SetActive(false);
		}
		foreach (GameObject item in items2){
			item.SetActive(true);
		}

}
}
