using UnityEngine;
using System.Collections;

public class RandomColor : MonoBehaviour {

	public Camera camera;

	// Use this for initialization
	void Start () {
		camera.clearFlags = CameraClearFlags.SolidColor;
		camera.backgroundColor = Random.ColorHSV (0f, 1f, 0.6f, 1f, 0.7f, 0.8f);
	}

}
