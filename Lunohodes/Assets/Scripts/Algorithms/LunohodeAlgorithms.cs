using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public static class LunohodeAlgorithms
{
	public static List<Pair<Position, int>> PossibleMoves(Unit unit, Position pos) {
		var result = new List<Pair<Position, int>>();
		unit.abilities.ForEach(a => {
			if (a.IsRepositioning()) {
				var to = a.To(pos);
				if (to != null) {
					result.Add(new Pair<Position, int>(to, a.cost));
				}
			}
		});
		return result;
	}
}
