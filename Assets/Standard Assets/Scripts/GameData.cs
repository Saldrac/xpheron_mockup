using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameData : MonoBehaviour {
	public Transform player;
	public Camera player_camera;
	public Camera plane_camera;
	public int current_player_hp;
	public int max_player_hp;
	public bool day;
	public AudioSource camera_audiosource;
	public AudioClip day_music;
	public AudioClip night_music;
	public GameObject waypoint;
	public int coins;
	public Canvas victorycanvas;
	public Canvas diecanvas;



	// Use this for initialization
	void Start () {
		current_player_hp = max_player_hp;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		coins = 0;
	}
	
	// Update is called once per frame

	public void ApplyDamage(int damage){
		current_player_hp = current_player_hp - damage;
		//We clamp the new health so we ensure it's in valid range
		ClampHP();
		if(current_player_hp == 0)
			respawn();
	}

	public void Heal(int healed_amount){
		current_player_hp = current_player_hp + healed_amount;
		//We clamp the new health so we ensure it's in valid range
		ClampHP();
	}

	public void ClampHP(){
		current_player_hp = Mathf.Clamp(current_player_hp, 0, max_player_hp);
	}

	public void setWayPoint(GameObject new_waypoint){
		waypoint = new_waypoint;
	}

	public void respawn(){
		if(waypoint != null){
			player.position = waypoint.transform.position;
			player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			player.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			current_player_hp = max_player_hp;
		}
		else
			Application.LoadLevel(Application.loadedLevel);
	}


}
