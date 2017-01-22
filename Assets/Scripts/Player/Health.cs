using UnityEngine;
using System.Collections;


public class Health : MonoBehaviour {

    public int HealthAmount;
    CharacterController _controller;
    public Vector3 Velocity;
    Vector3 _lastPos;
    Hurter _hurter = null;

    [FMODUnity.EventRef]
    public string stingers = "event:/Stingers";       //Create the eventref and define the event path
    FMOD.Studio.EventInstance stingersEv;                //rolling event
    FMOD.Studio.ParameterInstance hitParam;    //speed param object

    private void Start() {
        _lastPos = transform.position;
        CharacterController _controller = GetComponent<CharacterController>();

        stingersEv = FMODUnity.RuntimeManager.CreateInstance(stingers);
        stingersEv.getParameter("hit", out hitParam);
        stingersEv.start();
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
                ScreenFade.FadeScreen(0.15f, 0.15f, Color.red);
                HealthAmount -= _hurter.Damage;
                StartCoroutine(PlayHitSound());
            }
            _hurter = null;
        }
    }

    IEnumerator PlayHitSound()
    {
        hitParam.setValue(1f);
        yield return new WaitForSeconds(0.1f);
        hitParam.setValue(0f);
    }

    private void OnCollisionEnter(Collision pCol) { 
        _hurter = pCol.gameObject.GetComponent<Hurter>();
    }
}
