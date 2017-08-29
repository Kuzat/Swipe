using UnityEngine;
using System.Collections;

public class Graphics : MonoBehaviour {

	public Camera camera;
	public float totalTime = 10;

	private Color color;
	private Color nextColor;
	private bool slide = false;
	private GameObject slider;
	private float journeyLength;
	private float startTime;

	void Start() { 
	}

	void Update() {
		if (slide) {
			float frac = (Time.time - startTime) / totalTime;
			if (frac >= 1) {
				Destroy (slider);
				slide = false;
			}
			if (slider.tag == "up") {
				slider.transform.position = Vector3.Lerp (new Vector3 (0, 0), new Vector3 (0, journeyLength), frac);
			} else if (slider.tag == "down") {
				slider.transform.position = Vector3.Lerp (new Vector3 (0, 0), new Vector3 (0, -journeyLength), frac);
			} else if (slider.tag == "left") {
				slider.transform.position = Vector3.Lerp (new Vector3 (0, 0), new Vector3 (-journeyLength, 0), frac);
			} else if (slider.tag == "right") {
				slider.transform.position = Vector3.Lerp (new Vector3 (0, 0), new Vector3 (journeyLength, 0), frac);
			}
		}
	}

	public SpriteRenderer getBack(SpriteRenderer move) {
		return move.GetComponentsInChildren<SpriteRenderer> ()[1];
	}

	public SpriteRenderer setRandomBackgroundColor(SpriteRenderer move) {
		SpriteRenderer back = move.GetComponentsInChildren<SpriteRenderer> ()[1];
		color = nextColor;
		// Resize to fit screen
		int scale = Mathf.Max(camera.pixelWidth, camera.pixelHeight) / 16;
		back.transform.localScale = new Vector3 (scale, scale);
		// Assign random color to background
		nextColor = Random.ColorHSV (0f, 1f, 0.6f, 1f, 0.7f, 0.8f);
		back.color = Color.Lerp(nextColor, Color.grey, 0);
		return back;
	}

	public void slideOut(SpriteRenderer move) {
		if (slider != null) {
			Destroy (slider);
		}
		slider = move.gameObject;
		startTime = Time.time;

		journeyLength = getBack(move).transform.localScale.x;
		slide = true;
	}

	public void updateBackgroundColor(SpriteRenderer move, float time) {
		getBack (move).color = Color.Lerp(color, Color.grey, time);
	}

}
