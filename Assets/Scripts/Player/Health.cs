using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int HealthAmount;
    CharacterController _controller;
    public Vector3 Velocity;
    Vector3 _lastPos;
    Hurter _hurter = null;

    private void Start() {
        _lastPos = transform.position;
        CharacterController _controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update () {
        //Debug.Log("Health " + HealthAmount);
	    if (HealthAmount <= 0) {
            LevelManager.Instance.RestartLevel();
        }
	}

    private void LateUpdate()
    {
        Vector3 lastVelocity = Velocity;
        Velocity = (transform.position - _lastPos)/Time.deltaTime;
        Velocity = Vector3.Lerp(lastVelocity, Velocity, Time.deltaTime);
        _lastPos = transform.position;
        if (_hurter != null)
        {
            float relativeSpeed = (Velocity - _hurter.Velocity).magnitude;
            //Debug.Log("Relative Speed " + relativeSpeed);
            if (relativeSpeed>=_hurter.SpeedToHurt) {
                HealthAmount -= _hurter.Damage;
            }
            _hurter = null;
        }
    }

    private void OnCollisionEnter(Collision pCol) { 
        _hurter = pCol.gameObject.GetComponent<Hurter>();
    }
}
