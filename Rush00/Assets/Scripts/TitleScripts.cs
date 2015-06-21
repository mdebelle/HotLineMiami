using UnityEngine;
using System.Collections;

public class TitleScripts : MonoBehaviour {


	public void LaunchGame() {
		Application.LoadLevel("Level1");
	}
	
	public void QuitGame() {
		Application.Quit();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
