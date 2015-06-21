using UnityEngine;
using System.Collections;

public class TextEffect : MonoBehaviour {
	
	private float angle = 0.005f;
	public float t = 3f;

	void Start() {
		StartCoroutine ("ChangeDirection");
	}

	IEnumerator ChangeDirection() {
		while (true) {
			yield return new WaitForSeconds (t);
			t = 6f;
			angle *= -1;
		}
	}

	void FixedUpdate () {
		transform.Rotate (new Vector3(0.0f, 0.0f, angle), Time.deltaTime * 5f, 0);
	}
}