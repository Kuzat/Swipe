using UnityEngine;
using System.Collections;

public class SwipeDetector : MonoBehaviour {

	private string swipeDir;
	public float minSwipeDistY;
	public float minSwipeDistX;
	private Vector2 startPos;

	// returns swipedir and nulls it
	public string getSwipeDir() {
		string temp = swipeDir;
		swipeDir = "";
		return temp;
	}

	public bool getSwipe(string dir) {
		string temp = swipeDir;
		swipeDir = "";
		return dir == temp;
	}

	public bool emptySwipe() {
		return string.IsNullOrEmpty (swipeDir);
	}

	void Update() {
		if (Input.touchCount > 0) {

			Touch touch = Input.touches [0];

			switch (touch.phase) {

			case TouchPhase.Began:
				startPos = touch.position;
				break;

			case TouchPhase.Ended:
				float swipeDistVertical = (new Vector3 (0, touch.position.y, 0) - new Vector3 (0, startPos.y, 0)).magnitude;

				if (swipeDistVertical > minSwipeDistY) {

					float swipeValue = Mathf.Sign (touch.position.y - startPos.y);

					if (swipeValue > 0) {
						// up swipe
						swipeDir = "up";
						break;
					} else if (swipeValue < 0) {
						// down swipe
						swipeDir = "down";
						break;
					}

				}

				float swipeDistHorizontal = (new Vector3 (touch.position.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;

				if (swipeDistHorizontal > minSwipeDistX) {

					float swipeVaule = Mathf.Sign (touch.position.x - startPos.x);

					if (swipeVaule > 0) {
						// right swipe
						swipeDir = "right";
						break;
					} else if (swipeVaule < 0) {
						// left swipe
						swipeDir = "left";
						break;
					}

				}

				break;

			}

		}
	}

}
