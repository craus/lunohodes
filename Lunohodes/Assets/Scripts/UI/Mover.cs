using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.UI;

public class Mover : MonoBehaviour {
	public Image image;
	public void Update() {
		image.color = Game.instance.mover.color;
	}
}
