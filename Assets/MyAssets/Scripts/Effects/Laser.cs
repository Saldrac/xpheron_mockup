using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
	public LineRenderer laser;
	public GameObject point;
	public GameObject laserOrigin;

	private Ray ray;
	private RaycastHit hit;
	
	void Update()
	{
	
		ray = new Ray(laser.transform.position, laser.transform.forward);
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{	
			point.transform.position = hit.point;
			//laser.SetPosition(0, laserOrigin.transform.localPosition);
			//laser.SetPosition(1, hit.point);
			Debug.Log ("IF");
		}
		else
		{
			point.transform.position = ray.direction * 1000;
			//laser.SetPosition(0, laserOrigin.transform.localPosition);
			//laser.SetPosition(1, ray.direction * 1000);
		}
	
	}
}