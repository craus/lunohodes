using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

		transform.SetParent(position.transform, worldPositionStays: false);
	}
}
