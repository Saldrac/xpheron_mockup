using UnityEngine;
using System.Collections;

public class lightbounce : MonoBehaviour {

	public float max_intensity;
	public float min_intensity;
	public float interval;
	private Light m_light;
	// Use this for initialization
	void Start () {
		m_light = GetComponent<Light>();
		m_light.intensity = max_intensity;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
			m_light.intensity = Mathf.Clamp(m_light.intensity + Mathf.Sin(Random.Range(-1.0f,1.0f)) * interval, min_intensity, max_intensity);
	}
}
