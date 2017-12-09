using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCS : MonoBehaviour
{
    private void Update()
    {
        // runns all effectors
    }
}


public abstract class Affector
{
    public abstract void Run();
}