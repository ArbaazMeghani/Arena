using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

	public int damageAmount = 10;

	void OnCollisionEnter(Collision other) {
		Debug.Log ("Collision Test");
		Health playerHealth = other.gameObject.GetComponent<Health> ();
		if (playerHealth == null)
			Debug.Log ("Null");
		if (playerHealth != null)
			playerHealth.TakeDamage (damageAmount);

		Destroy (gameObject);
	}
}
