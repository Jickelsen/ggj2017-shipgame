using UnityEngine;
using System.Collections;

public class SlopeMovement : MonoBehaviour {

    public float Slipperyness;
    CharacterController _characterController;

	// Use this for initialization
	void Start () {
        _characterController = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit)) {
            Vector3 horizontalVector = new Vector3(Slipperyness * hit.normal.x, 0f, Slipperyness * hit.normal.z);
            Vector3 projectedVector = Vector3.Project(horizontalVector, hit.normal);
            Vector3 groundVector = horizontalVector - projectedVector;
            _characterController.Move(Slipperyness * groundVector);
        }
    }

}
