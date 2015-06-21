using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class PlayerScripts : MonoBehaviour {


	public GameObject bodyrotation; 
	public Camera cam;
	bool equiped = false;
	bool life = true;

	float fAngle;

	public List<GunsScripts> liste = new List<GunsScripts>();
	GunsScripts mygun;

	public GameObject bullets;
	public GameObject spwan;
	public float fireRate = 0.02f;
	private float nextFire;

	Vector3 v3Pos;

	#region triggercollision DropWeapon

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Weapon") {
			Debug.Log ("Catchable gun");
		}
	}

	void OnTriggerStay2D (Collider2D coll) {
		if (coll.gameObject.tag == "Weapon" && equiped == false) {
			if (Input.GetKeyDown (KeyCode.E)) {
				coll.gameObject.SetActive(false);
				equiped = true;
				Debug.Log ("Catch gun");
				for (int i = 0; i < liste.Count; i++) {
					if (!liste [i].isActiveAndEnabled) {
						mygun = liste [i];
						break;
					}
				}
			}
		}
		if (coll.gameObject.tag == "Bullet") {
			life = false;
		}
	}

	void OnTriggerExit2D (Collider2D coll) {
		if (coll.gameObject.tag == "Weapon") {
			Debug.Log ("UnCatchable gun");
		}
	}

	void DropWeapon() {
		for (int i = 0; i < liste.Count; i++) {
			if (liste [i].isActiveAndEnabled)
				continue;
			else {
				liste [i].transform.position = transform.position;
				liste [i].transform.position += Vector3.up;
				liste [i].gameObject.SetActive (true);
				liste [i].transform.Translate (Vector3.up * Time.deltaTime);
				equiped = false;
			}
		}
	}
		
	#endregion

	void Start () {

	}

	void Update () {
	
		movePlayer ();
		if (Input.GetMouseButton (1) && equiped == true) {
			Debug.Log ("Drop it");
			DropWeapon();
		}
		if (Input.GetMouseButton (0) && equiped == true && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject obj = Instantiate (bullets, spwan.transform.position, Quaternion.identity) as GameObject;
			obj.GetComponent<SpriteRenderer>().enabled = true;
			obj.AddComponent<BulletScripts>();
			Debug.Log (v3Pos.normalized);
			obj.GetComponent<BulletScripts>().direction = v3Pos.normalized;
				//		audio.Play();
		}

		if (life == false)
			ResetLevel ();

	}

	#region movePlayer

	void movePlayer () {

		if (Input.GetKey ("a")) {
			transform.Translate(Vector3.left * Time.deltaTime * 5);
		}
		if (Input.GetKey ("s")) {
			transform.Translate(Vector3.down * Time.deltaTime * 5);
		}
		if (Input.GetKey ("w")) {
			transform.Translate(Vector3.up * Time.deltaTime * 5);
		}
		if (Input.GetKey ("d")) {
			transform.Translate(Vector3.right * Time.deltaTime * 5);
		}
		
		v3Pos = Camera.main.WorldToScreenPoint(bodyrotation.transform.position);
		v3Pos = Input.mousePosition - v3Pos;
		fAngle = Mathf.Atan2 (v3Pos.y, v3Pos.x)* Mathf.Rad2Deg;
		if (fAngle < -90.0f) fAngle += 360.0f;

		if (bodyrotation.transform.localRotation.z <= 270f && bodyrotation.transform.localRotation.z >= -90f) {
			bodyrotation.transform.localEulerAngles = new Vector3 (0f, 0f, fAngle - 90f);
		}

		cam.transform.position = transform.position;
		cam.transform.position += new Vector3 (0f, 0f, -10f);

	}

	#endregion

	#region Someone is dead

	void ResetLevel ()
	{
		if (life == false)
			Debug.Log ("Tes mort");
	}

	#endregion
}
