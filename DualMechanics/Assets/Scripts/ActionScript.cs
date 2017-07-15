using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionScript : MonoBehaviour {

    public GameObject Detail;
    public Text Flavour;
    MasterScript Mref;
    string TextUse;
    string DetailUse;

    public void Setup(string T, string D, MasterScript M, GameObject G, Text F)
    {
        TextUse = T;
        DetailUse = D;
        Mref = M;
        Detail = G;
        Flavour = F;
    }
    public void CloseDetail()
    {
        Detail.SetActive(false);
    }
    public void Opendetail()

    {
        Detail.SetActive(true);
       
        Flavour.text = DetailUse;
    }
    public void Pressed()
    {
        Mref.Sref.PlaySound(3);
        Mref.Cref.useskill(TextUse);
        CloseDetail();
    }
}
