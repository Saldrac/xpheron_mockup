using UnityEngine;
using System.Collections;

public class Load_Scene : MonoBehaviour {

	public void LoadScene(int scene_id){
		Application.LoadLevel(scene_id);
	}
}
