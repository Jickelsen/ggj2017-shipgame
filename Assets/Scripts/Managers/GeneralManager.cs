using UnityEngine;
using System.Collections;

public class GeneralManager : MonoBehaviour {

    public WaveManager WaveManager;
    public Vector4[] WavesAmpxPerxAmpzPerz;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnLevelLoaded(int pLevel) {
        Debug.Log("Level loaded" + pLevel);
        WaveManager.AmplitudeX = WavesAmpxPerxAmpzPerz[pLevel].x;
        WaveManager.PeriodX = WavesAmpxPerxAmpzPerz[pLevel].y;
        WaveManager.AmplitudeZ = WavesAmpxPerxAmpzPerz[pLevel].z;
        WaveManager.PeriodZ = WavesAmpxPerxAmpzPerz[pLevel].w;
    }
}
