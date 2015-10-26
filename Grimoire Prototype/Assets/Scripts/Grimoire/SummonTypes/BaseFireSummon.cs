using UnityEngine;
using System.Collections;

public class BaseFireSummon : BaseSummon
{
    public BaseFireSummon()
    {
        Summon_Class = "Phoenix";
        Summon_Description = "A fire bird";
        Strength = 20;
        Defense = 10;
        Health = 80;
    }
}
