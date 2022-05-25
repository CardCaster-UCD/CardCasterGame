using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] string currentScene;
    [SerializeField] string nextScene;
    [SerializeField] VectorValue playerPosition;
    [SerializeField] Vector3 nextScenePosition;
    private bool triggered = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !triggered)
        {
            // Prevents this from being triggered twice after async calls.
            triggered = true;
            
            playerPosition.value = nextScenePosition;
            
            SceneManager.UnloadSceneAsync(currentScene);

            SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        }
    }    
}
