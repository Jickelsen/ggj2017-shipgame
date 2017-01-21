using UnityEngine;
using System.Collections;

public class KeepUpright : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	}
	
	void LateUpdate () {
        Quaternion currentRotation = GetComponent<Rigidbody>().rotation;
        //Quaternion correctedRotation = Quaternion.RotateTowards(currentRotation, Quaternion.identity, 360f);
        Quaternion correctedRotation = Quaternion.FromToRotation(transform.up, Vector3.up)*transform.rotation;

        //GetComponent<Rigidbody>().MoveRotation(correctedRotation);
        //GetComponent<Rigidbody>().MoveRotation(Quaternion.Slerp(transform.rotation, correctedRotation, Time.deltaTime * 10.0f));
        //GetComponent<Rigidbody>().rotation = correctedRotation;
        //GetComponent<Rigidbody>().rotation = Quaternion.Slerp(transform.rotation, correctedRotation, Time.deltaTime * 10.0f);
        transform.rotation = correctedRotation;
	}
}
