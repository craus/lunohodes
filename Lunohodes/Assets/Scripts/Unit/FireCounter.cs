using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCounter : MonoBehaviour {
	public List<Sprite> numberSprites;

	public Image image;

	public void Update() {
		var mover = Game.instance.mover;
		if (mover == null) {
			image.enabled = false;
			return;
		}
		var unit = mover.controller.current;
		if (unit == null) {
			image.enabled = false;
			return;
		}
		var fire = unit.abilityEffectInProgress as Fire;
		if (fire == null) {
			image.enabled = false;
			return;
		}

		image.enabled = true;
		image.sprite = numberSprites[Mathf.Clamp(fire.distance, 0, numberSprites.Count - 1)];
	}
}
