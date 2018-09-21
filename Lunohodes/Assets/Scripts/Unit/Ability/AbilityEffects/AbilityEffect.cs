using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbilityEffect : MonoBehaviour {
	public List<Cell> possibleTargets;

	public enum Status
	{
		Default,
		Usable,
		Unusable,
		WaitingCell
	}

	public virtual Status GetStatus(Unit unit) {
		return Status.Usable;
	}

	public virtual void Use(Unit unit) {
	}

	public virtual void CellClicked(Unit unit, Cell cell) {
	}

	public virtual void Interrupt(Unit unit) {
		unit.abilityEffectInProgress = null;
	}
}
