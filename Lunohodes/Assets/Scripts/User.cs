using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class User : Singletone<User> {
	public new Camera camera;

	public Unit current;

	public Transform highlight;
	public Transform selectedUnit;

	public Cell hovered;

	public List<Unit> lunohodes;

	public List<string> unitKeys;

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
		lunohodes = FindObjectsOfType<Unit>().ToList();
	}

	public void Select(Unit l) {
		current = l;
		l.StartMove();
	}

	public void Update() {
		unitKeys.ForEach(key => {
			if (Input.GetButtonDown(key)) {
				current.OnKeyPress(key);
			}
		});
		if (Input.GetButtonDown("Next Lunohode")) {
			Select(lunohodes.CyclicNext(current));
		}
		if (Input.GetMouseButtonDown(0)) {
			var underCursor = lunohodes.FirstOrDefault(l => l.figure.position == hovered);
			if (underCursor != null) {
				Select(underCursor);
			}
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
