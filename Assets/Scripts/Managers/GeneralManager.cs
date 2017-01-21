using UnityEngine;
using System.Collections;

public class GeneralManager : MonoBehaviour {

    public Vector4[] WavesAmpxPerxAmpzPerz;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnLevelLoaded(int pLevel) {
        WaveManager.Instance.AmplitudeX = WavesAmpxPerxAmpzPerz[pLevel].x;
        WaveManager.Instance.PeriodX = WavesAmpxPerxAmpzPerz[pLevel].y;
        WaveManager.Instance.AmplitudeZ = WavesAmpxPerxAmpzPerz[pLevel].z;
        WaveManager.Instance.PeriodZ = WavesAmpxPerxAmpzPerz[pLevel].w;
    }

    private static GeneralManager _instance = null;
    public static GeneralManager Instance
    {
        get
        {
            //If _instance hasn't been set yet, we grab it from the scene!
            //This will only happen the first time this reference is used.
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<GeneralManager>();
            return _instance;
        }
    }
}
