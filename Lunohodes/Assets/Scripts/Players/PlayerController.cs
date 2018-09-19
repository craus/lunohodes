using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public abstract class PlayerController : MonoBehaviour {
	public Player player;

	public Unit current;

	public virtual void StartMove() {
	}

	public virtual void StartUnitMove(Unit unit) {
	}

	public void Select(Unit unit) {
		if (unit == null || unit.moves < 1) {
			return;
		}
		if (current != null) {
			current.EndMove();
		}
		current = unit;
		current.StartMove();
	}
}
