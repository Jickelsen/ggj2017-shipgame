using UnityEngine;
using System.Collections;

public class Hurter : MonoBehaviour {
    public int Damage;
    public float SpeedToHurt;
    public Vector3 Velocity;
    Vector3 _lastPos;

    void Start () {
        _lastPos = transform.position;
    }

	void Update () {
        Debug.DrawRay(transform.position, Velocity);
	
	}
    private void LateUpdate()
    {
        Vector3 lastVelocity = Velocity;
        Velocity = (transform.position - _lastPos)/Time.deltaTime;
        Velocity = Vector3.Lerp(lastVelocity, Velocity, Time.deltaTime);
        _lastPos = transform.position;
    }

}