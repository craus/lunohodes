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
	public Transform normalBody;

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
		} else {
			ghostBody.SetParent(null);
		}
	}

	public void Update() {
		if (!Extensions.Editor()) {
			ghostBody.gameObject.SetActive(false);
			normalBody.gameObject.SetActive(true);
			if (
				unit.owner.user != null &&
				unit.owner.user.current == unit &&
				unit.owner.user.hovered != null &&
				unit.abilityEffectInProgress == null &&
				unit.pathFinder.AvailableInThisTurn(unit.owner.user.hoveredPosition)
			) {
				ghostBody.gameObject.SetActive(true);
				ghostBody.position = unit.owner.user.hovered.transform.position;

				ghostBody.transform.eulerAngles = Vector3.up * 90 * (1 - unit.owner.user.hoveredDirection);

//				if (unit.owner.user.hovered == unit.figure.position) {
//					normalBody.gameObject.SetActive(false);
//				}
			}
		}
	}

	public void OnDestroy() {
		if (!Extensions.Editor()) {
			if (ghostBody != null) {
				Destroy(ghostBody.gameObject);
			}
		}
	}
}
