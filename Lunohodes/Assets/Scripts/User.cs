using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : Singletone<User> {
	public Lunohode current;

	public void Update() {
		if (Input.GetButtonDown("Forward")) {
			current.figure.Move(current.directed.direction);
		}
		if (Input.GetButtonDown("Backward")) {
			current.figure.Move(current.directed.direction, -1);
		}
		if (Input.GetButtonDown("Right")) {
			current.directed.Rotate(-1);
		}
		if (Input.GetButtonDown("Left")) {
			current.directed.Rotate(1);
		}
	}
}
