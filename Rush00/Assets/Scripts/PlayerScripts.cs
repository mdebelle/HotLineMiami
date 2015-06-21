using UnityEngine;
using System.Collections;

public class PlayerScripts : MonoBehaviour {


	public GameObject bodyrotation; 
	public Camera cam;

	GameObject Weapon;


	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Weapon") {
			Debug.Log ("Hihi");
		}
	}

	void OnTriggerExit2D (Collider2D coll)
	{
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		movePlayer ();



	}

	void movePlayer () {

		if (Input.GetKey ("a")) {
			transform.Translate(Vector3.left * Time.deltaTime * 5);
		}
		if(Input.GetKey ("s")) {
			transform.Translate(Vector3.down * Time.deltaTime * 5);
		}
		if(Input.GetKey ("w")) {
			transform.Translate(Vector3.up * Time.deltaTime * 5);
		}
		if(Input.GetKey ("d")) {
			transform.Translate(Vector3.right * Time.deltaTime * 5);
		}
		
		Vector3 v3Pos = Camera.main.WorldToScreenPoint(bodyrotation.transform.position);
		v3Pos = Input.mousePosition - v3Pos;
		float fAngle = Mathf.Atan2 (v3Pos.y, v3Pos.x)* Mathf.Rad2Deg;
		if (fAngle < -90.0f) fAngle += 360.0f;

		if (bodyrotation.transform.localRotation.z <= 270f && bodyrotation.transform.localRotation.z >= -90f) {
			bodyrotation.transform.localEulerAngles = new Vector3 (0f, 0f, fAngle - 90f);
		}

		cam.transform.position = transform.position;
		cam.transform.position += new Vector3 (0f, 0f, -10f);

	}
}
