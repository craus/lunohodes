using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class User : PlayerController {
	public new Camera camera;

	public Transform highlight;
	public Transform selectedUnit;

	public Cell hovered;

	public List<string> unitKeys;

	public UnityEvent onLowEnergy;

	RaycastHit hit;
	public void CheckHovered() {
		Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit);
		if (hit.collider != null) {
			hovered = hit.collider.GetComponentInParent<Cell>();
		} else {
			hovered = null;
		}
	}

	public void Update() {
		if (player == Game.instance.mover) {
			unitKeys.ForEach(key => {
				if (Input.GetButtonDown(key) && current != null) {
					var status = current.OnKeyPress(key);
					if (status == Ability.Status.LowEnergy) {
						onLowEnergy.Invoke();
					}
				}
			});
			if (Input.GetButtonDown("End Turn")) {
				Debug.LogFormat("End Turn");
				Game.instance.NextMove();
			}
			if (Input.GetMouseButtonDown(0)) {
				var underCursor = Unit.all.FirstOrDefault(l => l.figure.position == hovered);
				if (underCursor != null && underCursor.moves > 0) {
					Select(underCursor);
				}
			}
		}
		CheckHovered();

		if (hovered != null) {
			highlight.position = hovered.transform.position;
		}
		highlight.gameObject.SetActive(hovered != null);


	}
}
