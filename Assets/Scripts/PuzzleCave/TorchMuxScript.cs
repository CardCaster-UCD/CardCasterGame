using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchMuxScript : RockController 
{
    [SerializeField] GameObject yellowTorch;
    [SerializeField] GameObject purpleTorch;
    [SerializeField] GameObject greenTorch;
    [SerializeField] GameObject yellowRock;
    [SerializeField] GameObject blueRock;
    
    void Start()
    {
        if (yellowTorch is null) throw new NullReferenceException("Required serialized field [yellowTorch] is unassigned");
        if (purpleTorch is null) throw new NullReferenceException("Required serialized field [purpleTorch] is unassigned");
        if (greenTorch  is null) throw new NullReferenceException("Required serialized field [greenTorch] is unassigned" );
        if (yellowRock  is null) throw new NullReferenceException("Required serialized field [yellowRock] is unassigned" );
        if (blueRock    is null) throw new NullReferenceException("Required serialized field [blueRock] is unassigned"   );
    }

    public new void OnTorchStateChanged(bool isEnflamed)
    {
        Action<Action<bool>> yellowTorchSubscribe = yellowTorch.GetComponent<TorchController>().Subscribe;
        Action<Action<bool>> purpleTorchSubscribe = purpleTorch.GetComponent<TorchController>().Subscribe;
        Action<Action<bool>> greenTorchSubscribe  = greenTorch.GetComponent<TorchController>().Subscribe;

        Action<Action<bool>> yellowTorchUnsubscribe = yellowTorch.GetComponent<TorchController>().Unsubscribe;
        Action<Action<bool>> purpleTorchUnsubscribe = purpleTorch.GetComponent<TorchController>().Unsubscribe;
        Action<Action<bool>> greenTorchUnsubscribe  = greenTorch.GetComponent<TorchController>().Unsubscribe;

        Action<bool> yellowRockToggle  = yellowRock.GetComponent<RockController>().OnTorchStateChanged;
        Action<bool> blueRockToggle    = blueRock.GetComponent<RockController>().OnTorchStateChanged;
        

        if (isEnflamed)
        {
            yellowTorchUnsubscribe(yellowRockToggle);
            purpleTorchUnsubscribe(blueRockToggle);
            greenTorchUnsubscribe(blueRockToggle);

            yellowTorchSubscribe(blueRockToggle);
            purpleTorchSubscribe(yellowRockToggle);
            greenTorchSubscribe(yellowRockToggle);
        }
        else
        {
            yellowTorchUnsubscribe(blueRockToggle);
            purpleTorchUnsubscribe(yellowRockToggle);
            greenTorchUnsubscribe(yellowRockToggle);

            yellowTorchSubscribe(yellowRockToggle);
            purpleTorchSubscribe(blueRockToggle);
            greenTorchSubscribe(blueRockToggle);
        }
    }
}
