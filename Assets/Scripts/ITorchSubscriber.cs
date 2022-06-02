using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITorchSubscriber
{
    public void OnTorchStateChanged(bool isEnflamed);
}
