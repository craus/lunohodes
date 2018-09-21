using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class User : PlayerController {
	public new Camera camera;

	public static User instance;

	public Transform highlight;
	public Transform selectedUnit;

	public Cell hovered;
	public int hoveredDirection;

	public List<string> unitKeys;

	public LayerMask cellsMask;

	public UnityEvent onLowEnergy;

	public void Awake() {
		instance = this;
	}

	public int PointDirection(Vector3 localCellPoint) {
		if (Mathf.Abs(localCellPoint.x) > Mathf.Abs(localCellPoint.z)) {
			if (localCellPoint.x < 0) {
				return 2;
			} else {
				return 0;
			}
		} else {
			if (localCellPoint.z < 0) {
				return 3;
			} else {
				return 1;
			}
		}
	}

	RaycastHit hit;
	public void CheckHovered() {
		Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, float.PositiveInfinity, cellsMask);
		if (hit.collider != null) {
			hovered = hit.collider.GetComponentInParent<Cell>();
			if (hovered != null) {
				var localHitPoint = hovered.transform.InverseTransformPoint(hit.point);
				hoveredDirection = PointDirection(localHitPoint);
			}
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
				FinishMove();
			}
			if (Input.GetMouseButtonDown(0)) {
				if (current != null) {
					current.CellClicked(hovered);
				}
				var underCursor = Game.instance.units.FirstOrDefault(l => l.figure.position == hovered);
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
