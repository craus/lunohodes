using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyCounter : MonoBehaviour {
	public List<Sprite> numberSprites;

	public Image image;

	public Animator lowEnergy;

	public void Update() {
		image.enabled = User.instance.current != null;
		image.sprite = numberSprites[Mathf.Clamp(User.instance.current.energy, 0, numberSprites.Count-1)];
	}

	public void OnLowEnergy() {
		lowEnergy.SetTrigger("LowEnergy");
	}
}
