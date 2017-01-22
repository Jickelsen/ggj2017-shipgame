using UnityEngine;
using System.Collections;

public class PlayStingerOnAcc : MonoBehaviour {

    [FMODUnity.EventRef]
    public string stingers = "event:/Stingers";       //Create the eventref and define the event path
    FMOD.Studio.EventInstance stingersEv;                //rolling event
    FMOD.Studio.ParameterInstance param;    //speed param object

    public string ParameterName;
    public float AccelerationToMakeSound;
    Vector3 _velocity;
    Vector3 _acceleration;
    Vector3 _lastPos;
    Vector3 _lastVelocity;

    // Use this for initialization
    void Start () {
        _lastPos = transform.position;

        stingersEv = FMODUnity.RuntimeManager.CreateInstance(stingers);
        stingersEv.getParameter(ParameterName, out param);
        stingersEv.start();
	}

    void LateUpdate() {
        Vector3 lastAcceleration = _acceleration;
        _velocity = (transform.position - _lastPos) / Time.deltaTime;
        if (_lastVelocity == null) {
            _lastVelocity = _velocity;
        }
        _acceleration = (_velocity - _lastVelocity) / Time.deltaTime;
        //Debug.Log("Acceleration " + _acceleration.magnitude);
        //_acceleration = Vector3.Lerp(lastAcceleration, _acceleration, Time.deltaTime);
        if (_acceleration.magnitude >= AccelerationToMakeSound) {
            StartCoroutine(PlaySound());
        }
        _lastPos = transform.position;
        _lastVelocity = _velocity;
    }

    IEnumerator PlaySound() {
        param.setValue(1f);
        yield return new WaitForSeconds(1.5f);
        param.setValue(0f);
    }

}
