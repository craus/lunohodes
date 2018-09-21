using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Health : MonoBehaviour {
	public Unit unit;

	public int max = 3;
	public int current = 3;

	public void Hit(int damage) {
		current -= damage;
		if (current <= 0) {
			Die();
		}
	}

	public void Die() {
		Destroy(unit.gameObject);
	}
}
