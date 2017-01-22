﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{

    bool _started = false;
    bool _resetToLevel = false;
    int _startedLevel;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _startedLevel = SceneManager.GetActiveScene().buildIndex;
    }
    // Update is called once per frame
    void Update()
    {
        if (_started)
        {
            Starter[] starters = FindObjectsOfType(typeof(Starter)) as Starter[];

            foreach (Starter other in starters)
            {
                if (!((object)this.gameObject).Equals((object)other.gameObject))
                {
                    Destroy(other.gameObject);
                }
            }
        }
        if (!_resetToLevel && _startedLevel != 0) {
            LevelManager levelManager = FindObjectOfType<LevelManager>();
            if (levelManager != null) {
                StartCoroutine(ResetTolevel(_startedLevel));
            }
        }
    }

    IEnumerator ResetTolevel(int pIndex) {
        _resetToLevel = true;
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Resetting to level" + pIndex);
        LevelManager.Instance.SetLevel(pIndex);
    }

    void LateUpdate()
    {
        // Debug.Log("Application loadedlevel is " + Application.loadedLevel);
        if (!_started && _startedLevel != 0)
        {
            _started = true;
            SceneManager.LoadScene(0);
        }
        else
        {
            _started = true;
        }
    }
}