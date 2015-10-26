using UnityEngine;
using System.Collections;

public class BaseEarthSummon : BaseSummon
{
    public BaseEarthSummon()
    {
        Summon_Class = "Golem";
        Summon_Description = "A titanic earthen monster";
        Strength = 5;
        Defense = 20;
        Health = 120;
    }
}
