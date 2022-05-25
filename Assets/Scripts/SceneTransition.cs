using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] string SceneName;
    [SerializeField] VectorValue playerPosition;
    [SerializeField] CameraBounds cameraBounds = null;
    [SerializeField] Vector3 nextScenePosition;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
            playerPosition.value = nextScenePosition;
            SceneManager.LoadSceneAsync(SceneName);
        }
    }    
}
