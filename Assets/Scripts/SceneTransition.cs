using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] string SceneName;
    [SerializeField] Vector2 playerPosition;
    [SerializeField] VectorValue playerStorage;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene(SceneName);
        }
    }    
}
