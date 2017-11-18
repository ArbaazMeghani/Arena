﻿using System.Collections;
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
			currentHealth = 0;
			Debug.Log ("Dead!");
		}

		healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
	}

	void OnChangeHealth(int health) {
		healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
	}
}
