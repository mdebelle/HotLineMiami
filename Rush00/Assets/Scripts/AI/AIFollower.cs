using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class AIFollower : MonoBehaviour {

	protected NavMeshAgent agent;
	[SerializeField]private Transform spwan;

	public Transform target;

	void Start() {
		agent = GetComponent<NavMeshAgent> ();
	}

	void LateUpdate() {
		agent.SetDestination (target.position);
	}

	void FixedUpdate() {
//		Instantiate (bullet, spwan.position, Quaternion.identity);
	}
}