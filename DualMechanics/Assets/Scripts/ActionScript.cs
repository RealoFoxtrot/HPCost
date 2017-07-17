using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionScript : MonoBehaviour {

    public GameObject Detail;
    public Text Flavour;
    MasterScript Mref;
    string TextUse;
    string DetailUse;
    SkillClass Sref;


    public void Setup(SkillClass S, MasterScript M, GameObject G, Text F)
    {
        Sref = S;
        TextUse = S.NameSkill;
        DetailUse = S.DescribeSkill;
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
        if (Mref.Gref.BattleMode)
        {
            Mref.Sref.PlaySound(3);
            Mref.Cref.useskill(TextUse);
            CloseDetail();
        }
        else if (Mref.Gref.RespiteMode)
        {
            if (Mref.Cref.Will > Sref.LearnCost - 1)
            {
                Mref.Cref.boostwill(-Sref.LearnCost);
                Mref.Cref.Learned.Add(Sref);
                Mref.Uref.UpdateStats();
                Destroy(gameObject);
            }
           
        }
    }
}
