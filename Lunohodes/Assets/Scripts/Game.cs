using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Game : Singletone<Game> {
	public List<Player> players;

	public Player mover;

	public void NextMove() {
		mover.EndMove();
		mover = players.CyclicNext(mover);
		mover.StartMove();
	}

	public void Start() {
		mover.StartMove();
	}
}
