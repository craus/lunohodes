using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTrajectory : MonoBehaviour {
	public LineRenderer line;

	public void Update() {
		var user = Game.instance.mover.user;
		if (user == null || user.hovered == null) {
			line.gameObject.SetActive(false);
			return;
		}
		var unit = user.current;
		if (unit == null || unit.abilityEffectInProgress != null || !unit.pathFinder.AvailableInThisTurn(user.hoveredPosition)) {
			line.gameObject.SetActive(false);
			return;
		}
		line.gameObject.SetActive(true);
		var path = unit.pathFinder.Path(user.hoveredPosition);

		line.positionCount = path.Count;
		for (int i = 0; i < path.Count; i++) {
			line.SetPosition(i, path[i].first.cell.transform.position);
		}
	}
}
