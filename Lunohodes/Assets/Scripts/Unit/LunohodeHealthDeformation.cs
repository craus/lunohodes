using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LunohodeHealthDeformation : MonoBehaviour {
	public Transform track;
	public Unit unit;
	public Vector3 basePosition;
	public Vector3 deformedPosition;
	public int healthThreshold;

	public void Update() {
		track.localPosition = unit.health.current > healthThreshold ? basePosition : deformedPosition;
	}
}
