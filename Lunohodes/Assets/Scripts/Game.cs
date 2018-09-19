using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Game : Singletone<Game> {
	public List<Player> players;

	public Player mover;

	public void NextMove() {
		mover = players.CyclicNext(mover);
	}

	public void Start() {
		FindObjectsOfType<Unit>().Where(u => u.owner == mover).ForEach(u => u.moves = 1);
	}
}
