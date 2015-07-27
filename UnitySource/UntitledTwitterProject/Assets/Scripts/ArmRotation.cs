using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {

	bool m_FacingRight = true;

	// Update is called once per frame
	void Update () {
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize ();

		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ);
		Debug.Log (m_FacingRight + " " + rotZ);

		if (((rotZ > 90f && rotZ < 180f) || (rotZ > -180f && rotZ < -90f)) && m_FacingRight) {
			flip ();
		} else if (((rotZ > -90f && rotZ < 0f) || (rotZ >= 0f && rotZ < 90f)) && !m_FacingRight) {
			flip ();
		}
	}

	void flip () {
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
		transform.localScale = theScale;
	}
}
