using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {

    public int value;
    public MasterScript Mref;

    public void Setup(int V, MasterScript M)
    {
        value = V;
        Mref = M;
    }

    public void Pressed()
    {
        Mref.Gref.Target = value;
    }
}
