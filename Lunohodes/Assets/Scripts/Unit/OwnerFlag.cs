using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

[ExecuteInEditMode]
public class OwnerFlag : MonoBehaviour {
	public Unit unit;
	public List<MeshRenderer> renderers;

	public void Start() {
		if (unit != null && unit.owner != null) {
			renderers.ForEach(r => r.sharedMaterial = unit.owner.flagMaterial);
		}
	}
}
