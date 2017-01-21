using UnityEngine;
using System.Collections;

public class SlopeMovement : MonoBehaviour {

    public float Slipperyness;
    CharacterController _characterController;
    Rigidbody _rigidBody;

	// Use this for initialization
	void Start () {
        _characterController = gameObject.GetComponent<CharacterController>();
        _rigidBody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position - Vector3.up * 0.1f, -WaveManager.Instance.TiltReference.up);
        if (Physics.Raycast(transform.position-Vector3.up*0.1f, -WaveManager.Instance.TiltReference.up, out hit)) {
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
