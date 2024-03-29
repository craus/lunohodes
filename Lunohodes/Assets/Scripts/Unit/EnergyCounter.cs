﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyCounter : MonoBehaviour {
	public List<Sprite> numberSprites;

	public Image image;

	public Animator lowEnergy;

	public void Update() {
		image.enabled = Game.instance.mover.user != null && Game.instance.mover.user.current != null;
		if (image.enabled) {
			image.sprite = numberSprites[Mathf.Clamp(Game.instance.mover.user.current.energy, 0, numberSprites.Count - 1)];
		}
	}

	public void OnLowEnergy() {
		lowEnergy.SetTrigger("LowEnergy");
	}
}
