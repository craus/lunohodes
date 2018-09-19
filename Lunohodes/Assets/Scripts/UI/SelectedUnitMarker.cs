using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.UI;

public class SelectedUnitMarker : MonoBehaviour {
	public Transform marker;

	public void Update() {
		if (Game.instance.mover.controller.current != null) {
			marker.position = Game.instance.mover.controller.current.figure.position.transform.position;
		}
		marker.gameObject.SetActive(Game.instance.mover.controller.current != null);
	}
}
