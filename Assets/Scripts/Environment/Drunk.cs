using UnityEngine;
using System.Collections;

public class Drunk : MonoBehaviour {

    public float DrunkDuration;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    IEnumerator GetDrunk(float duration)
    {
        yield return new WaitForSeconds(duration);

    }

    private void OnCollisionEnter(Collision pCol) {
        if (pCol.gameObject.CompareTag("Drink"))
        {
            StartCoroutine(GetDrunk(DrunkDuration));
        }
    }
}
