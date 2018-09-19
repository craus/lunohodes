using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class SelectionAnimator : MonoBehaviour {
	public Animator animator;

	public Unit unit;

	public void Update() {
		animator.SetBool("Selected", unit.owner.controller.current == unit);
	}
}

