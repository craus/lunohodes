using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
    public int n = 8;
    public float size = 10;
    public Cell cellSample;
    public Material white;
    public Material black;

    [ContextMenu("Create")]
    void Create() {
        transform.Children().ForEach(t => DestroyImmediate(t.gameObject));
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                var cell = Instantiate(cellSample);
                cell.GetComponent<MeshRenderer>().sharedMaterial = (i + j) % 2 == 0 ? white : black;
                cell.transform.position = new Vector3(size * i, 0, size*j);
                cell.transform.SetParent(transform);
            }
        }
    }
}
