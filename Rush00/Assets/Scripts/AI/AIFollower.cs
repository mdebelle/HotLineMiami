using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class AIFollower : MonoBehaviour {

	protected NavMeshAgent agent;

	public Transform target;

	void Start() {
		agent = GetComponent<NavMeshAgent> ();
	}

	void LateUpdate() {
		agent.SetDestination (target.position);
	}
}