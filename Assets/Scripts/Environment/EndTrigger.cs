using UnityEngine;
using System.Collections;

public class EndTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger tag " + other.gameObject.tag);
        if (other.CompareTag("Player")) {
            LevelManager.Instance.NextLevel();
        }
    }
}
