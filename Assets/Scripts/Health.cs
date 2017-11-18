﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

	public const int maxHealth = 100;
	public RectTransform healthBar;
	public bool destroyOnDeath;

	[SyncVar(hook = "OnChangeHealth")]
	private int currentHealth = maxHealth;

	private NetworkStartPosition[] spawnPoints;

	void Start() {
		if (!isLocalPlayer)
			return;
		spawnPoints = FindObjectsOfType<NetworkStartPosition>();
	}

	public void TakeDamage(int amount) {
		if (!isServer)
			return;
		
		currentHealth -= amount;

		if (currentHealth <= 0) {
			if (destroyOnDeath)
				Destroy (gameObject);
			else {
				currentHealth = maxHealth;
				RpcRespawn ();
			}
		}

		healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
	}

	void OnChangeHealth(int health) {
		healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
	}

	[ClientRpc]
	void RpcRespawn() {
		if (!isLocalPlayer)
			return;
		
		Vector3 spawnPoint = Vector3.zero;

		if (spawnPoints != null && spawnPoints.Length > 0)
			spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
		transform.position = spawnPoint;
	}
}
