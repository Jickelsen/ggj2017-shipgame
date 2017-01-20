using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

    public float AmplitudeX;
    public float PeriodX;
    public float AmplitudeZ;
    public float PeriodZ;
    float _runningTime;

    public Transform RotatedObject;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        float newRotX = AmplitudeX * (Mathf.Sin(2*Mathf.PI*(_runningTime + Time.deltaTime)/PeriodX)-Mathf.Sin(2*Mathf.PI*_runningTime/PeriodX));
        float newRotZ = AmplitudeZ * (Mathf.Sin(2*Mathf.PI*(_runningTime + Time.deltaTime)/PeriodZ)-Mathf.Sin(2*Mathf.PI*_runningTime/PeriodZ));
        _runningTime += Time.deltaTime;
        //Debug.Log("Rot X " + newRotX + " Rot Z " + newRotZ);
        RotatedObject.Rotate(new Vector3(newRotX, 0f, 0f), Space.World);
        RotatedObject.Rotate(new Vector3(0f, 0f, newRotZ), Space.Self);
	}

}
