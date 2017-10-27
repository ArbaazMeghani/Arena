using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
	public override void OnStartLocalPlayer() {
		gameObject.GetComponentInChildren<MeshRenderer> ().material.color = Color.blue;
		gameObject.transform.SetPositionAndRotation (new Vector3 (0, 1, 0), gameObject.transform.rotation);
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