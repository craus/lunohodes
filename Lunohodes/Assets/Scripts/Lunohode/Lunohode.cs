using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunohode : MonoBehaviour {
	public Figure figure;
	public Directed directed;

	public Animator selectionAnimator;

	public void Update() {
		selectionAnimator.SetBool("Selected", User.instance.current == this);
	}
}
