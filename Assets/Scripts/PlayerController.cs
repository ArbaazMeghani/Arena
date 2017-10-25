using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
	public override void OnStartLocalPlayer() {
		GetComponent().material.color = Color.blue;
	}

	void Update() {
		if (!isLocalPlayer)
			return;
		float horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		float verticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, horizontalMovement, 0);
		transform.Translate(0, 0, verticalMovement);
	}
}