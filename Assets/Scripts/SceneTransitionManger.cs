using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransitionManger : MonoBehaviour
{
    // if cameraBounds is not null, the camera already has its bounds set when the scene is loaded
    [SerializeField] public StringValue currentScene;
    [SerializeField] private string startScene;
    [SerializeField] private string UI;
    [SerializeField] private Vector3 spawn;
    [SerializeField] private VectorValue initialPosition;

    void Start()
    {
        // This is the dude that contains the coordinates of where the player should be 
        // at the start of every scene
        initialPosition.value = spawn;
        
        SceneManager.LoadSceneAsync(startScene, LoadSceneMode.Additive);
        currentScene.value = startScene;

        SceneManager.LoadSceneAsync(UI, LoadSceneMode.Additive);
    }
}
