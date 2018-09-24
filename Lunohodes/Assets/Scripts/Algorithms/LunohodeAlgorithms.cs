using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public static class LunohodeAlgorithms
{
	public static List<Pair<Ability, Position>> PossibleMoves(Unit unit, Position pos) {
		var result = new List<Pair<Ability, Position>>();
		unit.abilities.ForEach(a => {
			if (a.IsRepositioning()) {
				var to = a.To(pos);
				if (to != null) {
					result.Add(new Pair<Ability, Position>(a, a.To(pos)));
				}
			}
		});
		return result;
	}
}
