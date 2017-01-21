﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Handles level changes and notifies GeneralManager of level changes
public class LevelManager : MonoBehaviour {

    private int _currentLevel = 0;
    public int LoadedLevel
    {
        get
        {
            return _currentLevel;
        }
        set
        {
            SetLevel(value);
        }
    }
	// Use this for initialization
	void Awake () {
        _currentLevel += 1;
        LevelFade.LoadLevel(_currentLevel, 0.1f, 1f, Color.black);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetLevel(int pIndex) {
        _currentLevel = pIndex;
        Debug.Log("Set level " + pIndex);
        SceneManager.LoadScene(pIndex);
    }

    public void NextLevel() {
        Debug.Log("Next level " + (_currentLevel+1));
        _currentLevel += 1;
        LevelFade.LoadLevel(_currentLevel, 1f, 1f, Color.black);
    }

    public void RestartLevel() {
        LevelFade.LoadLevel(_currentLevel, 1f, 1f, Color.red);
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
