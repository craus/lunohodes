using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour {
	public List<Sprite> numberSprites;

	public Image image;
	public Transform root;
	public GameObject images;

	public void Update() {
		var user = Game.instance.mover.user;
		if (user == null || user.hovered == null) {
			images.SetActive(false);
			return;
		}
		var unit = user.current;
		var target = user.hoveredUnit;
		if (unit == null || target == null || target == unit) {
			images.SetActive(false);
			return;
		}
		if (!unit.CanFire(target)) {
			images.SetActive(false);
			return;
		}
		images.SetActive(true);
		var cost = unit.Position.cell.Distance(target.Position.cell);
		image.sprite = numberSprites[Mathf.Clamp(cost, 0, numberSprites.Count - 1)];

		var ghostPoint = Game.instance.mover.user.camera.WorldToScreenPoint(target.transform.position);
		root.transform.position = ghostPoint;
	}
}
