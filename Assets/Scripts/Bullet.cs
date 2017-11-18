using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

	public int damageAmount = 10;

	void OnCollisionEnter(Collision other) {
		Destroy (gameObject);
		if(other.gameObject.CompareTag("Player")) {
			gameObject.GetComponent<Health> ().TakeDamage (damageAmount);
		}
	}
}
