using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RSG;

public class Controls : Singletone<Controls> {
	public void Update() {
		var user = Game.instance.mover.user;

		user.ReadInput();
	}
}
