using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbilityEffect : MonoBehaviour {
	public virtual bool Usable(Unit unit) {
		return true;
	}

	public virtual void Use(Unit unit) {
	}

	public virtual void CellClicked(Unit unit, Cell cell) {
	}
}
