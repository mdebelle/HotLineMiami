using UnityEngine;
using System.Collections;

public class EiffelTour : MonoBehaviour {

	private Vector3 add = new Vector3(0.01f, 0.01f, 0.01f);
	private Vector3 nil = new Vector3(0f, 0f, 0f);

	void FixedUpdate () {
		if (transform.localScale.x > 2.2f)
			transform.localScale = nil;
		else
			transform.localScale += add;
	}
}
