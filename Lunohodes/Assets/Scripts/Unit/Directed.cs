using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Directed : MonoBehaviour {
	public int direction;
	public const int DIRECTIONS = 4;

	[ContextMenu("Direct")]
	public void Direct() {
		transform.eulerAngles = Vector3.up * 90 * (1 - direction);
	}

	public void Direct(int direction) {
		this.direction = direction;
		Direct();
	}

	public void Update() {
		if (Extensions.Editor()) {
			Direct();
		}
	}

	public void Rotate(int delta) {
		direction += delta;
		direction = direction.modulo(DIRECTIONS);
		Direct();
	}
}
