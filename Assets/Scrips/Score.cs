using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private static int score;
	public Text scoreText;

	void Start () {
		//DontDestroyOnLoad (gameObject);
		if (score > PlayerPrefs.GetInt ("highscore")) {
			PlayerPrefs.SetInt ("highscore", score);
		}
	}

	public void setScore(int value) {
		score = value;
	}

	public int getScore() {
		return score;
	}

	public void setScoreText(Text text) {
		scoreText = text;
	}

	public void UpdateScore() {
		score += 1;
	}

	private void UpdateScoreText() {
		scoreText.text = score.ToString();
	}

	// Update is called once per frame
	void Update () {
		UpdateScoreText ();
	}
}
