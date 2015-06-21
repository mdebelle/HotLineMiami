using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIEnemy : MonoBehaviour {

	#region WayPoints
	[SerializeField]private List<Transform>Waypoints;
	private int currentWayPoint=0;
	private bool waypointModus=true;

	/*void Update() {
		if (!waypointModus) {
			if (lastVisiblePosition != Vector3.zero) {
				RotateTo (lastVisiblePosition);
				walk (lastVisiblePosition);
				if (CharacterAnimationState == AnimateState.idle && !isAttaking) {
					waypointModus = true;
				}
			} else {
				StopMoving ();
			}
		} else {
			if (Waypoints.Count == 0) {
				SetDynamicWayPoints ();
			}
			RotateTo (Waypoints [currentWayPoint].position);
			WaypointWalk ();
		}
	}

	void SetDynamicWayPoints()
	{
		GameObject firstCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		firstCube.name="xd1";
		Destroy (firstCube.collider);
		//firstCube.renderer.enabled=false;
		firstCube.transform.position=transform.position;
		Waypoints.Add(firstCube.transform);
		
		GameObject secondCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		secondCube.name="xd2";
		Destroy (secondCube.collider);
		//secondCube.renderer.enabled=false;
		Vector3 pos2=transform.TransformPoint(Vector3.forward*(-4));
		secondCube.transform.position=pos2;
		Waypoints.Add(secondCube.transform);
	}
	
	void ClearWaypoints() 
	{
		foreach (Transform tf in Waypoints)
		{Destroy(tf.gameObject);}
		Waypoints.Clear();
	}*/
	#endregion

	#region Enemy
	void OnTriggerEnter(Collider other) {
		print (other.name);
		if (other.tag == "Player") {
			transform.GetComponent<AIFollower> ().enabled = true;
			transform.GetComponent<NavMeshAgent> ().enabled = true;
		}
	}

	IEnumerator WaitToStop () {
		yield return new WaitForSeconds (5f);
		transform.GetComponent<AIFollower> ().enabled = false;
		transform.GetComponent<NavMeshAgent> ().enabled = false;
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			StartCoroutine("WaitToStop");
		}
	}
	#endregion
}