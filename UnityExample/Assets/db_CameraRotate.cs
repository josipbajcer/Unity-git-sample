/*

As discussed earlier, iOS devices have a defined access that allows us to determine changes
in the device's orientation. We can detect this as changes in the x, y, or z values in Input.
acceleration:

*/


using UnityEngine;
using System.Collections;


public class CameraRotate : MonoBehaviour {

	public float speed = 10.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame

	void Update () {

		Vector3 direction = Vector3.zero;
		direction.x = - Input.acceleration.y;
		direction.z = Input.acceleration.x;

		if ( direction.sqrMagnitude > 1 )
		{
			direction.Normalize();
		}
		direction *= Time.deltaTime;
		transform.Translate( direction * speed );
	}
}