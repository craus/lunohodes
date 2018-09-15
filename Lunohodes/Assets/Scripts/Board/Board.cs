using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Board : MonoBehaviour {
	public int n = 8;
    public int m = 9;
    public float size = 10;
    public Cell cellSample;
    public Material white;
    public Material black;

	public Cell[,] cells;

	public bool Inside(int x, int y) {
		return 0 <= x && x < n && 0 <= y && y < m;
	}

	public Cell GetCell(int x, int y) {
		return Inside(x, y) ? cells[x, y] : null;
	}

	void Start() {
		cells = new Cell[n, m];
		FindObjectsOfType<Cell>().ForEach(c => cells[c.x, c.y] = c);
	}

	[ContextMenu("Clear")]
	public void Clear() {
		transform.Children().ForEach(t => Extensions.Destroy(t.gameObject));
	}

    [ContextMenu("Create")]
	void Create() {
		Clear();
		cells = new Cell[n, m];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                var cell = Instantiate(cellSample);
				cell.x = i;
				cell.y = j;
				cells[i, j] = cell;
				cell.board = this;
                cell.GetComponent<MeshRenderer>().sharedMaterial = (i + j) % 2 == 0 ? white : black;
                cell.transform.position = new Vector3(size * i, 0, size*j);
                cell.transform.SetParent(transform);
            }
        }

		var lunohode = Extensions.Instantiate(Library.instance.lunohode);
		lunohode.figure.Place(cells[n / 2, m / 2]);
		User.instance.current = lunohode;
    }
}
