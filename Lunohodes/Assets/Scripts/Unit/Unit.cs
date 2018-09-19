using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
	public static List<Unit> all = new List<Unit>();

	public Figure figure;
	public Directed directed;

	public List<Ability> abilities; 
	public List<AbilityKeyBind> binds;

	public Player owner;

	public int energy;
	public int moves;

	public void StartMove() {
		moves--;
		energy = Random.Range(1, 7);
	}

	public Ability.Status OnKeyPress(string key) {
		var result = Ability.Status.Default;
		binds.ForEach(b => {
			if (b.key == key) {
				var status = b.ability.GetStatus(this);
				if (status == Ability.Status.Usable) {
					b.ability.Use(this);
				}
				result = status;
			}
		});
		return result;
	}

	public void Start() {
		all.Add(this);
	}

	public void OnDestroy() {
		all.Remove(this);
	}
}
