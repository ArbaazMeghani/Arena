using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Billboard : NetworkBehaviour {
	
	void Update () {
		transform.LookAt(Camera.main.transform);
	}
}
