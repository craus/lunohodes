using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

[ExecuteInEditMode]
public class OwnerFlag : MonoBehaviour {
	public Unit unit;
	public List<MeshRenderer> renderers;

	public void Apply() {
		if (unit != null && unit.owner != null) {
			var material = new Material(renderers[0].sharedMaterial);
			material.color = unit.owner.color;
			renderers.ForEach(r => r.sharedMaterial = material);
		}
	}
}
