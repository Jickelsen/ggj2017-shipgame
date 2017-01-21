using UnityEngine;
using System.Collections;

// Handles level changes and notifies GeneralManager of level changes
public class LevelManager : MonoBehaviour {

    private int _currentLevel;

	// Use this for initialization
	void Start () {
        GeneralManager.Instance.OnLevelLoaded(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NextLevel() {
        LevelFade.LoadLevel(_currentLevel+1, 1f, 1f, Color.black);
    }

    private static LevelManager _instance = null;

    public static LevelManager Instance
    {
        get
        {
            //If _instance hasn't been set yet, we grab it from the scene!
            //This will only happen the first time this reference is used.
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<LevelManager>();
            return _instance;
        }
    }
}
