using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	public override void OnStartLocalPlayer() {
		gameObject.GetComponentInChildren<MeshRenderer> ().material.color = Color.blue;
		gameObject.transform.SetPositionAndRotation (new Vector3 (0, 1, 0), gameObject.transform.rotation);
	}

	void Update() {
		if (!isLocalPlayer)
			return;

		if(Input.GetButton("Fire1"))
			Fire();
		float horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		float verticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, horizontalMovement, 0);
		transform.Translate(0, 0, verticalMovement);
	}

	void Fire() {
		GameObject bullet = Instantiate (
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
		Destroy(bullet, 2.0f);
	}
}