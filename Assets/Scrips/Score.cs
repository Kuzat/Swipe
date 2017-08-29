using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private static int score;
	public Text scoreText;
	public Text highScore;

	void Start () {
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
		if (scoreText != null) {
			scoreText.text = score.ToString();	
		}
		if (highScore != null) {
			highScore.text = PlayerPrefs.GetInt ("highscore").ToString();
		}
	}

	// Update is called once per frame
	void Update () {
		UpdateScoreText ();
	}
}
