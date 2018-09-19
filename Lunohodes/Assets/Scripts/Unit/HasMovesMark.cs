using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

[ExecuteInEditMode]
public class HasMovesMark : MonoBehaviour {
	public Unit unit;
	public GameObject mark;

	public void Update() {
		mark.SetActive(unit.moves > 0);
	}
}
