using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class LineRendererColorSetter : MonoBehaviour {
	public Color c;
	public LineRenderer line;

	public void Update() {
		line.startColor = line.endColor = c;
	}

	public void LateUpdate() {
		line.startColor = line.endColor = c;
	}
}
