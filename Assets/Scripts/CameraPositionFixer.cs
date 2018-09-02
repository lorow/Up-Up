using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionFixer : MonoBehaviour {

    [SerializeField]
    Transform cube;
    [SerializeField]
    float speed;
    [SerializeField]
    float yOffseft = 2;

	// Update is called once per frame
	void Update () {
		if (cube.position.y != transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x,
                                                cube.position.y + yOffseft,
                                                transform.position.z);

            transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);
        }
	}
}
