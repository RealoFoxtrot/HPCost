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
        if (Mref.Gref.Location.Encounters[value].Active)
        {
            Debug.Log(value);
            Mref.Gref.Target = value;
            Mref.Sref.PlaySound(3);
        }

    }
}
