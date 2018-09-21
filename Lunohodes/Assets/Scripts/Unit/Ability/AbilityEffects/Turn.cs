using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : AbilityEffect, RepositioningEffect {
	public int deltaDirection;

	public override void Use(Unit unit) {
		unit.directed.Rotate(deltaDirection);
	}

	public Position To(Position from) {
		return new Position(from.cell, (from.direction + deltaDirection).modulo(Directed.DIRECTIONS));
	}
}
