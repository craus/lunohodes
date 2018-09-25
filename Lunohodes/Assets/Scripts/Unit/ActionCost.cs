using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionCost : MonoBehaviour {
	public List<Sprite> numberSprites;

	public Image image;
	public Transform root;
	public GameObject images;

	public Animator lowEnergy;

	public void Update() {
		var user = Game.instance.mover.user;
		if (user == null || user.hovered == null) {
			images.SetActive(false);
			return;
		}
		var unit = user.current;
		if (unit == null || !unit.pathFinder.AvailableInThisTurn(user.hoveredPosition)) {
			images.SetActive(false);
			return;
		}
		images.SetActive(true);
		var cost = unit.pathFinder.availableCells[user.hoveredPosition];
		if (cost > unit.energy) {
			cost = 0;
		}
		image.sprite = numberSprites[Mathf.Clamp(cost, 0, numberSprites.Count - 1)];

		var ghostPoint = Game.instance.mover.user.camera.WorldToScreenPoint(Game.instance.mover.user.current.ghostBody.ghostBody.position);
		root.transform.position = ghostPoint;
	}

	public void OnLowEnergy() {
		lowEnergy.SetTrigger("LowEnergy");
	}
}
