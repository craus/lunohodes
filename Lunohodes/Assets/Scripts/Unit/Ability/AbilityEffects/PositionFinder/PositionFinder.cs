using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PositionFinder : MonoBehaviour {
	public virtual Cell Position(Position position) {
		return null;
	}
}
