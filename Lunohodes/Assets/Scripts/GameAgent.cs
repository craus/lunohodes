using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using RSG;

public class GameAgent : Singletone<GameAgent> {
	public void Awake() {
		Promise.EnablePromiseTracking = true;
		Promise.UnhandledException += (object sender, ExceptionEventArgs e) => {
			Debug.LogException(e.Exception);
		};
	}
}
