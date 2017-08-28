using UnityEngine;
using System.Collections;

public class Logic : MonoBehaviour {

	public ScreenManager screenManager;
	public SwipeDetector swipeDetector;
	public Score score;
	public Graphics graphics;
	KeyCode key;
	private float timeLeft;
	private float totalDuration;
	public SpriteRenderer up;
	public SpriteRenderer down;
	public SpriteRenderer left;
	public SpriteRenderer right;
	private SpriteRenderer move;
	private SpriteRenderer nextMove;

	void Start() {
		move = Instantiate (getRandomMove ());
		graphics.setRandomBackgroundColor (move).enabled = true;
		move.enabled = true;
		nextMove = Instantiate (getRandomMove ());
		graphics.setRandomBackgroundColor (nextMove).enabled = false;

		timeLeft = getRoundTime (score.getScore ());
		totalDuration = timeLeft;
	}

	void Update() {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			//WrongMove ();
		}
		graphics.updateBackgroundColor (move, 1 - timeLeft / totalDuration);
		GetRightMove ();
	}

	private void getNextMove() {
		move = nextMove;
		move.enabled = true;
		graphics.getBack (move).enabled = true;
		nextMove = Instantiate (getRandomMove ());
		graphics.setRandomBackgroundColor (nextMove).enabled = false;
	}

	public void GetRightMove() {
		if (move.gameObject.tag == "left") {
			if (Input.GetKeyDown(KeyCode.LeftArrow) || swipeDetector.getSwipe("left")) {
				RightMove();
			} else if (Input.GetKeyDown(KeyCode.UpArrow) ||Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || !swipeDetector.emptySwipe()){
				WrongMove ();
			}
		}
		else if (move.gameObject.tag == "down") {
			if (Input.GetKeyDown (KeyCode.DownArrow) || swipeDetector.getSwipe("down")) {
				RightMove ();
			} else if (Input.GetKeyDown(KeyCode.UpArrow) ||Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || !swipeDetector.emptySwipe()){
				WrongMove ();
			}
		}
		else if (move.gameObject.tag == "right") {
			if (Input.GetKeyDown(KeyCode.RightArrow) || swipeDetector.getSwipe("right")) {
				RightMove();
			} else if (Input.GetKeyDown(KeyCode.UpArrow) ||Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || !swipeDetector.emptySwipe()){
				WrongMove ();
			}
		}
		else if (move.gameObject.tag == "up") {
			if (Input.GetKeyDown(KeyCode.UpArrow) || swipeDetector.getSwipe("up")) {
				RightMove();
			} else if (Input.GetKeyDown(KeyCode.RightArrow) ||Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || !swipeDetector.emptySwipe()){
				WrongMove ();
			}
		}
	}
		

	public void RightMove() {
		print ("You did the right move!");
		score.UpdateScore ();

		print(getRoundTime(score.getScore()));

		graphics.slideOut (move);
		// get new move
		getNextMove ();

		timeLeft = getRoundTime (score.getScore ());
		totalDuration = timeLeft;
	}

	public void WrongMove() {
		print ("You did the wrong move!");
		screenManager.LoadScreen ("Lose");
	}

	private float getRoundTime(int roundNumber) {
		return (3f / (Mathf.Exp (roundNumber / 10f))) + 0.515f;
	}

	private SpriteRenderer getRandomMove() {
		int randomChoice = Random.Range (0, 4);
		SpriteRenderer randomSprite = null;
		switch (randomChoice) {
		case 0:
			randomSprite = up;
			break;
		case 1:
			randomSprite = down;
			break;
		case 2:
			randomSprite = left;
			break;
		case 3:
			randomSprite = right;
			break;
		default:
			print("Random move does not exist");
			break;			
		}

		return randomSprite;
	}

}
