using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

[ExecuteInEditMode]
public class GhostBody : MonoBehaviour {
	public Unit unit;
	public List<MeshRenderer> renderers;

	public Transform ghostBody;

	[ContextMenu("Apply")]
	public void Apply() {
		renderers.ForEach(r => {
			var material = new Material(r.sharedMaterial);
			Extensions.ChangeAlpha(material, 0.5f);
			r.sharedMaterial = material;
		});
	}

	public void Start() {
		if (Extensions.Editor()) {
			Apply();
		}
	}

	public void Update() {
		if (!Extensions.Editor()) {
			ghostBody.gameObject.SetActive(false);
			if (
				unit.owner.user != null &&
				unit.owner.user.current == unit &&
				unit.pathFinder.Available(unit.owner.user.hovered)
			) {
				ghostBody.gameObject.SetActive(true);
				ghostBody.position = unit.owner.user.hovered.transform.position;

				ghostBody.transform.eulerAngles = Vector3.up * 90 * (1 - unit.owner.user.hoveredDirection);
			}
		}
	}
}
