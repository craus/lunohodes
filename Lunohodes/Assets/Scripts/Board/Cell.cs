using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
	public List<Figure> figures;

	public Board board;

	public int x;
	public int y;

	public Cell Shifted(int dx, int dy) {
		return board.GetCell(x + dx, y + dy);
	}

	public Cell ToDirection(int dir, int dist = 1) {
		return Shifted(dist * (int)Mathf.Cos(dir * Mathf.PI/2), dist * (int)Mathf.Sin(dir * Mathf.PI/2));
	}
}
