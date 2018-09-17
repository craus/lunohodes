using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : Singletone<User> {
	public new Camera camera;

	public Lunohode current;

	public Transform highlight;

	public Cell hovered;

	RaycastHit hit;
	public void CheckHovered() {
		Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit);
		Debug.LogFormat("collider = {0}", hit.collider);
		if (hit.collider != null) {
			hovered = hit.collider.GetComponentInParent<Cell>();
		} else {
			hovered = null;
		}
	}

	public void Update() {
		if (Input.GetButtonDown("Forward")) {
			current.figure.Move(current.directed.direction, condition: c => c.figures.Count == 0);
		}
		if (Input.GetButtonDown("Backward")) {
			current.figure.Move(current.directed.direction, -1, condition: c => c.figures.Count == 0);
		}
		if (Input.GetButtonDown("Right")) {
			current.directed.Rotate(-1);
		}
		if (Input.GetButtonDown("Left")) {
			current.directed.Rotate(1);
		}
		CheckHovered();
		if (hovered != null) {
			highlight.position = hovered.transform.position;
		}
		highlight.gameObject.SetActive(hovered != null);
	}
}
