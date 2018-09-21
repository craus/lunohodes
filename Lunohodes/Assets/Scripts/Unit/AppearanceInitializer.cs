using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

[ExecuteInEditMode]
public class AppearanceInitializer : MonoBehaviour {
	public List<GhostBody> ghostBodies;
	public List<OwnerFlag> ownerFlags;

	public void Start() {
		Debug.LogFormat("Start");
		ownerFlags.ForEach(o => o.Apply());
		ghostBodies.ForEach(g => g.Apply());
	}
}
