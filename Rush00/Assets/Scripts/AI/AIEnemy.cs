using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIEnemy : AIFollower {

	private float targetDistance = 10;
	private bool isAttaking=false;
	private Vector3 lastVisiblePosition = Vector3.zero;
	private float minimalDistanceStandard = 3f;
	private float minimalDistance = 3f;
	
//	public GameObject projectile;
//	public Transform spawnPoint;
	
	public List<Transform>Waypoints;
	private int currentWayPoint=0;
	private bool waypointModus=true;


	void FindTarget() {
		RaycastHit hit;
		Ray ray=new Ray();
		ray.origin=transform.position;
		ray.direction=target.position - transform.position ;
		
		isAttaking=false;
		if (Physics.Raycast(ray,out hit,targetDistance))
		{
			if (hit.collider.gameObject.transform==target)
			{
				isAttaking=true ;
				lastVisiblePosition=target.position;
				waypointModus=false;
				ClearWaypoints();
				currentWayPoint=0;
				print("target found");
			}
		}
		if (isAttaking)
		{
			minimalDistance = minimalDistanceStandard;
		}
		else
		{
			minimalDistance=0.2f;
		}
	}

	void ClearWaypoints() 
	{
		foreach (Transform tf in Waypoints)
			Destroy(tf.gameObject);
		Waypoints.Clear();
	}

	protected void Update() {
		FindTarget ();
	}
}