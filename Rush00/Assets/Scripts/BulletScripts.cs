using UnityEngine;
using System.Collections;

public class BulletScripts : MonoBehaviour {


	public Vector3			direction;
//	public float 	rot;
//	public bool 	shoot;
//
//	// Use this for initialization
//	void Start () {
//			
//	}
//
//	void OnTriggerEnter2D(Collider2D coll)
//	{
//		Destroy (gameObject);
//	}
//
//
//	// Update is called once per frame
//	void Update () {
//
//		transform.Translate ((Vector2)direction * Time.deltaTime);
//	}

	public float SpeedBullet = 10f;
	
	void Update () {
		transform.Translate( direction * Time.deltaTime * SpeedBullet);
	}
	
	void OnCollisionEnter2D(Collision other) {
		Destroy(gameObject);
	}
}