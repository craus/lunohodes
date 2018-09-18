using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
	public Figure figure;
	public Directed directed;

	public List<Ability> abilities;
	public List<AbilityKeyBind> binds;

	public int energy;

	public Animator selectionAnimator;

	public void StartMove() {
		energy = Random.Range(1, 7);
	}

	public void OnKeyPress(string key) {
		binds.ForEach(b => b.OnKeyPress(this, key));
	}

	public void Update() {
		selectionAnimator.SetBool("Selected", User.instance.current == this);
	}
}
