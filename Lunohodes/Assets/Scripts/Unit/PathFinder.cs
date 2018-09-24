using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class PathFinder : MonoBehaviour {
	public Unit unit;

	public Map<Position, int> availableCells = new Map<Position, int>(() => int.MaxValue);
	public Map<Position, Pair<Position, Ability>> solution = new Map<Position, Pair<Position, Ability>>();

	public void UpdateMap() {
		availableCells = new Map<Position, int>(() => int.MaxValue);
		Algorithms.Dijkstra<Position, Pair<Ability, Position>, Ability>(
			availableCells, 
			unit.Position, 
			p => LunohodeAlgorithms.PossibleMoves(unit, p),
			a => a.first.cost,
			a => a.second, 
			solution,
			a => a.first
		);
	}

	public bool Available(Cell cell) {
		return availableCells.Any(p => p.Key.cell == cell && p.Value <= unit.energy);
	}

	public bool Available(Position position) {
		return availableCells[position] < int.MaxValue;
	}

	public List<Pair<Position, Ability>> Path(Position position) {
		var result = new List<Pair<Position, Ability>>();
		int steps = 100;

		result.Add(new Pair<Position, Ability>(position, null));
		while (!position.Equals(unit.Position)) {
			steps--;
			if (steps == 0) {
				break;
			}
			result.Add(solution[position]);
			position = solution[position].first;
		}
		result.Reverse();
		return result;
	}
}
