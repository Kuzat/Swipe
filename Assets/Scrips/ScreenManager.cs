using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour {

	public void LoadScreen(string name) {
		Debug.Log (name);
		SceneManager.LoadScene (name);
	}

	public void ExitGame() {
		Application.Quit ();
	}
}
