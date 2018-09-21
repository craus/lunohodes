using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Figure : MonoBehaviour {
	public Cell position;

	[Space]
	public Cell newPosition;

	[ContextMenu("Place")]
	public void Place() {
		Place(newPosition);
	}

	public void Leave() {
		if (position != null) {
			position.figures.Remove(this);
		}
	}

	public void Place(Cell position) {
		Leave();

		this.position = position;

		if (position != null) {
			position.figures.Add(this);
		}

		if (position != null) {
			transform.SetParent(position.transform, worldPositionStays: false);
		}
	}

	public bool Move(int direction, int dist = 1, Func<Cell, bool> condition = null) {
		if (condition == null) {
			condition = c => true;
		}
		Cell target = position.ToDirection(direction, dist);
		if (target != null && condition(target)) {
			Place(target);
			return true;
		}
		return false;
	}

	public void OnDestroy() {
		Leave();
	}
}
