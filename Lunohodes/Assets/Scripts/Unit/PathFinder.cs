using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class PathFinder : MonoBehaviour {
	public Unit unit;

	public Map<Position, int> availableCells = new Map<Position, int>();

	public void UpdateMap() {
		availableCells = new Map<Position, int>();
		Algorithms.Dijkstra(availableCells, unit.Position, p => LunohodeAlgorithms.PossibleMoves(unit, p));
	}

	public bool Available(Cell cell) {
		return availableCells.Any(p => p.Key.cell == cell && p.Value <= unit.energy);
	}
}
