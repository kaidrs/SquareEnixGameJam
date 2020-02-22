using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheP
{
    public string name;
    public int HP;

    public TheP(string name, int hP)
    {
        this.name = name;
        HP = hP;
    }

    public override string ToString()
    {
        return $"N:{name}, HP:{HP}";
    }

}
