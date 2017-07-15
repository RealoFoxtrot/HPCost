using UnityEngine;
using System.Collections;

[System.Serializable]
public class SkillClass {

    public string NameSkill;
    public string DescribeSkill;
    public int Willcost;
    public int LearnCost;
    public bool StartingSkill;
    public int Tier;
    public SkillClass RequiredtoLearn;

	public SkillClass()
    {

    }
}
