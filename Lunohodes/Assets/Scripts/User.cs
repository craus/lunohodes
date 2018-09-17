using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class User : Singletone<User> {
	public new Camera camera;

	public Lunohode current;

	public Transform highlight;
	public Transform selectedUnit;

	public Cell hovered;

	public List<Lunohode> lunohodes;

	RaycastHit hit;
	public void CheckHovered() {
		Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit);
		if (hit.collider != null) {
			hovered = hit.collider.GetComponentInParent<Cell>();
		} else {
			hovered = null;
		}
	}

	public void Start() {
		lunohodes = FindObjectsOfType<Lunohode>().ToList();
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
		if (Input.GetButtonDown("Next Lunohode")) {
			Debug.LogFormat("Next Lunohode");
			current = lunohodes.CyclicNext(current);
		}
		CheckHovered();

		if (hovered != null) {
			highlight.position = hovered.transform.position;
		}
		highlight.gameObject.SetActive(hovered != null);

		if (current != null) {
			selectedUnit.position = current.figure.position.transform.position;
		}
		selectedUnit.gameObject.SetActive(current != null);
	}
}
