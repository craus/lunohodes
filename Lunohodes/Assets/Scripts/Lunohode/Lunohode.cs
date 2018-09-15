using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunohode : MonoBehaviour {
    public Cell cell;
    public float direction;

    public List<Command> commands = new List<Command>();

    public void Update() {
        if (Input.GetAxis("Horizontal") > 0) {
        }
    }

    public void MoveForward() {

    }
}
