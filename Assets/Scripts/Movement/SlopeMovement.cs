using UnityEngine;
using System.Collections;

public class SlopeMovement : MonoBehaviour {

    public float Slipperyness;
    CharacterController _characterController;
    Rigidbody _rigidBody;
    Transform _tiltReference;

	// Use this for initialization
	void Start () {
        _characterController = gameObject.GetComponent<CharacterController>();
        _rigidBody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (_tiltReference == null) {
            _tiltReference = GameObject.FindGameObjectWithTag("LevelRoot").transform;
        }
	
	}

    void FixedUpdate()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position - Vector3.up * 0.1f, -_tiltReference.up);
        if (Physics.Raycast(transform.position-Vector3.up*0.1f, -_tiltReference.up, out hit)) {
            Vector3 horizontalVector = new Vector3(Slipperyness * hit.normal.x, 0f, Slipperyness * hit.normal.z);
            Vector3 projectedVector = Vector3.Project(horizontalVector, hit.normal);
            Vector3 groundVector = horizontalVector - projectedVector;
            _rigidBody.AddForce(Slipperyness * groundVector);
            //_characterController.Move(Slipperyness * groundVector);
        }
    }
    private static SlopeMovement _instance = null;
    public static SlopeMovement Instance
    {
        get
        {
            //If _instance hasn't been set yet, we grab it from the scene!
            //This will only happen the first time this reference is used.
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<SlopeMovement>();
            return _instance;
        }
    }

}
