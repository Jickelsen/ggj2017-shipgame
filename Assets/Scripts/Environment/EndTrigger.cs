using UnityEngine;
using System.Collections;

public class EndTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            LevelManager.Instance.CompletedGame();
        }
    }
}
