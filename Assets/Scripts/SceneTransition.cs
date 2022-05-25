using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] string SceneName;
    [SerializeField] VectorValue playerStorage;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
            playerStorage.value = other.transform.position;
            SceneManager.LoadSceneAsync(SceneName);
        }
    }    
}
