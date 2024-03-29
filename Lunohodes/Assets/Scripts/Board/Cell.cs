﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Cell : MonoBehaviour {
	public List<Figure> figures;

	public Board board;

	public int x;
	public int y;

	public TMPro.TextMeshPro text;
	public MeshRenderer cellRenderer;

	private void UpdateText() {
		text.text = $"({x}, {y})";
	}

	public void OnValidate() {
		UpdateText();
	}

	public void Start() {
		UpdateText();
	}

	public Cell Shifted(int dx, int dy) {
		return board.GetCell(x + dx, y + dy);
	}

	public Cell ToDirection(int dir, int dist = 1) {
		return Shifted(dist * (int)Mathf.Cos(dir * Mathf.PI/2), dist * (int)Mathf.Sin(dir * Mathf.PI/2));
	}

	public int Distance(Cell target) {
		return Mathf.Abs(x - target.x) + Mathf.Abs(y - target.y);
	}
}
