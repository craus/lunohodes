﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Player : MonoBehaviour {
	public Color color;
	public PlayerController controller;

	public User user {
		get {
			return controller as User;
		}
	}

	public void EndMove() {
		FindObjectsOfType<Unit>().Where(u => u.owner == this).ForEach(u => u.moves = u.energy = 0);
		if (controller.current != null) {
			controller.current.EndMove();
		}
		controller.current = null;
	}

	public void StartMove() {
		FindObjectsOfType<Unit>().Where(u => u.owner == this).ForEach(u => u.moves = 1);

		controller.StartMove();
	}
}
