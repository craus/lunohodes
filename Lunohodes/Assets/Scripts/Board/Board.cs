﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class Board : Singletone<Board> {
	public int n = 8;
    public int m = 9;
    public float size = 10;
    public Material white;
    public Material black;

	public Cell[,] cells;
	[SerializeField] private List<Cell> cellsList;

	public bool Inside(int x, int y) {
		return 0 <= x && x < n && 0 <= y && y < m;
	}

	public Cell GetCell(int x, int y) {
		return Inside(x, y) ? cells[x, y] : null;
	}

	void Start() {
		Create();
		Game.instance.Start();
	}

	public void RestoreCells() {
		cells = new Cell[n, m];
		FindObjectsOfType<Cell>().ForEach(c => cells[c.x, c.y] = c);
	}

	[ContextMenu("Clear")]
	public void Clear() {
		transform.Children().ForEach(t => Extensions.Destroy(t.gameObject));
	}

	public void OnValidate() {
		if (cells != null) {
			cellsList = cells.Cast<Cell>().ToList();
		}
	}

	[ContextMenu("Create")]
	void Create() {
		Clear();
		cells = new Cell[n, m];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
				var cell = Extensions.Instantiate(Library.instance.cell);
				cell.x = i;
				cell.y = j;
				cell.gameObject.name = "Cell {0}, {1}".i(i, j);
				cells[i, j] = cell;
				cell.board = this;
				cell.cellRenderer.sharedMaterial = (i + j) % 2 == 0 ? white : black;
                cell.transform.position = new Vector3(size * i, 0, size*j);
                cell.transform.SetParent(transform);
            }
        }

		foreach (Player p in Game.instance.players) {
			for (int i = 0; i < 4; i++) {
				var lunohode = Extensions.Instantiate(Library.instance.lunohode);
				lunohode.transform.position = Vector3.zero;
				lunohode.figure.Place(Rand.rnd(cells, c => c.figures.Count == 0));
				lunohode.directed.Direct(Random.Range(0, 4));
				lunohode.gameObject.name = "Lunohode #{0} ({1})".i(i, p.name);
				lunohode.owner = p;
			}
		}
    }
}
