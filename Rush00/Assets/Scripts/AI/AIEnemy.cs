using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIEnemy : MonoBehaviour {

	#region WayPoints
	[SerializeField]private List<Transform>Waypoints;

	private Vector3[] direction = new Vector3[2];
	private float speed = 2f;
	int id;
	
	void Start() {
		direction[0] = Vector3.forward;
		direction[1] = Vector3.back;
	}
	
	void Update() {
		transform.Translate (direction[id] * Time.deltaTime * speed);
	}
	#endregion
	
	#region Enemy
	void OnTriggerEnter(Collider other) {
		print (other.name);
		if (other.tag == "Player") {
			transform.GetComponent<AIFollower> ().enabled = true;
			transform.GetComponent<NavMeshAgent> ().enabled = true;
		} else if (other.transform == Waypoints[id]) {
			id = (id == 1)?0:1;
		}
	}

	IEnumerator WaitToStop () {
		yield return new WaitForSeconds (10f);
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