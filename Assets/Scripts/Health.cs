using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

	public const int maxHealth = 100;
	public RectTransform healthBar;

	[SyncVar(hook = "OnChangeHealth")]
	private int currentHealth = maxHealth;

	public void TakeDamage(int amount) {
		if (!isServer)
			return;
		currentHealth -= amount;
		if (currentHealth <= 0) {
			currentHealth = maxHealth;
			RpcRespawn ();
		}

		healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
	}

	void OnChangeHealth(int health) {
		healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
	}

	[ClientRpc]
	void RpcRespawn() {
		if (isLocalPlayer)
			transform.position = new Vector3 (0.0f, 1.0f, 0.0f);
	}
}
