using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	
	[SerializeField]private Text[] text = new Text[2];

	private int pos = 0;
	private Shadow[] shadow = new Shadow[2];
	private TextEffect[] effect = new TextEffect[2];

	void Start() {
		for (int i=0; i<2; i++) {
			shadow [i] = text [i].GetComponent<Shadow> ();
			effect [i] = text [i].GetComponent<TextEffect> ();
		}
	}

	void EnableStuff(int a, int b) {
		text[a].transform.rotation = Quaternion.Euler(0, 0, 0);
		effect [a].t = 3;
		shadow[a].enabled = false;
		shadow[b].enabled = true;
		effect[a].enabled = false;
		effect[b].enabled = true;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			if (pos > 0)
				pos--;
			EnableStuff(1, 0);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			if (pos < 1)
				pos++;
			EnableStuff(0, 1);
		}
		
		if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) {
			if (pos == 0)
				Application.LoadLevel(1);
			else
				Application.Quit();
		}
	}
}