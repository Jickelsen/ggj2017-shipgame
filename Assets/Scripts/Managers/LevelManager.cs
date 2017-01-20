using UnityEngine;
using System.Collections;

// Handles level changes and notifies GeneralManager of level changes
public class LevelManager : MonoBehaviour {

    public GeneralManager GeneralManager;

	// Use this for initialization
	void Start () {
        GeneralManager.OnLevelLoaded(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
