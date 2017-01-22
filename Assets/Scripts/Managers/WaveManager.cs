using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

    public float AmplitudeX;
    public float PeriodX;
    public float AmplitudeZ;
    public float PeriodZ;
    float _runningTime;

    public Transform RotatedObject;

	// Update is called once per frame
	void Update () {
        if (RotatedObject == null)
        {
            GameObject rotated = GameObject.FindGameObjectWithTag("LevelRoot");
            if (rotated != null)
            {
            RotatedObject = rotated.transform;
            } 
            _runningTime = 0f;
        }
        float newRotX = AmplitudeX * (Mathf.Sin(2*Mathf.PI*(_runningTime + Time.deltaTime)/PeriodX)-Mathf.Sin(2*Mathf.PI*_runningTime/PeriodX));
        float newRotZ = AmplitudeZ * (Mathf.Sin(2*Mathf.PI*(_runningTime + Time.deltaTime)/PeriodZ)-Mathf.Sin(2*Mathf.PI*_runningTime/PeriodZ));
        _runningTime += Time.deltaTime;
        //Debug.Log("Rot X " + newRotX + " Rot Z " + newRotZ);
        if (RotatedObject != null) {
            RotatedObject.Rotate(new Vector3(newRotX, 0f, 0f), Space.World);
            RotatedObject.Rotate(new Vector3(0f, 0f, newRotZ), Space.Self);
        }
	}

    private static WaveManager _instance = null;
    public static WaveManager Instance
    {
        get
        {
            //If _instance hasn't been set yet, we grab it from the scene!
            //This will only happen the first time this reference is used.
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<WaveManager>();
            return _instance;
        }
    }

}
