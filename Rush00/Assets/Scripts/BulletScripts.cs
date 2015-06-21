using UnityEngine;
using System.Collections;

public class BulletScripts : MonoBehaviour {

	public Vector3			direction;
	public float			SpeedBullet = 10f;

	void Update () {
		transform.Translate( new Vector3(direction.x, direction.z, 0) * Time.deltaTime * SpeedBullet);
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "en")
			Destroy(gameObject);
		Destroy(gameObject);
	}
}