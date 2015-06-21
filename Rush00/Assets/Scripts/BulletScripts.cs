using UnityEngine;
using System.Collections;

public class BulletScripts : MonoBehaviour {

	public Vector3			direction;
	public float			SpeedBullet = 10f;

	void Update () {
		transform.Translate( direction * Time.deltaTime * SpeedBullet);
	}

	void OnCollisionEnter(Collision other) {
		Destroy(gameObject);
	}
}