using UnityEngine;
using System.Collections;

public class PlaySoundOnAcc : MonoBehaviour {

    public float AccelerationToMakeSound;
    public AudioClip[] Clips;
    AudioSource _audioSource;
    Vector3 _velocity;
    Vector3 _acceleration;
    Vector3 _lastPos;
    Vector3 _lastVelocity;
    bool _playing = false;

    private void Awake()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.volume = 0.35f;
    }
    // Use this for initialization
    void Start () {
        _lastPos = transform.position;

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
        if (_acceleration.magnitude >= AccelerationToMakeSound && !_playing) {
            StartCoroutine(PlaySound());
        }
        _lastPos = transform.position;
        _lastVelocity = _velocity;
    }

    IEnumerator PlaySound() {
        _playing = true;
        _audioSource.PlayOneShot(Clips[(int)Mathf.Floor(Random.value*3.99f)]);
        Debug.Log("Playing clip " + (int)Mathf.Floor(Random.value * 3.99f));
        yield return new WaitForSeconds(2f);
        _playing = false;
    }

}
