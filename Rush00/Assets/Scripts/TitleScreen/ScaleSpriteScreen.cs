using UnityEngine;
using System.Collections;

public class ScaleSpriteScreen : MonoBehaviour {

	[SerializeField]private Camera cam;

	private float duration = 3.0f;
	private Color color1 = Color.red;
	private Color color2 = Color.blue;

	void Start() {
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if (sr == null) return;
		
		transform.localScale = new Vector3(1,1,1);
		
		float width = sr.sprite.bounds.size.x;
		float height = sr.sprite.bounds.size.y;
		
		float worldScreenHeight = (float)(Camera.main.orthographicSize * 2.0);
		float worldScreenWidth = (float)(worldScreenHeight / Screen.height * Screen.width);
		
		Vector2 tmp = new Vector2(worldScreenWidth / width, worldScreenHeight / height);
		transform.localScale = tmp;
	}

	void Update() {
		float t = Mathf.PingPong(Time.time, duration) / duration;
		cam.backgroundColor = Color.Lerp(color1, color2, t);
	}
}