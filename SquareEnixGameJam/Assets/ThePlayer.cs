using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class TheHero
{
    public float healthPoint;
    public int attackPoint;
    public int defencePoint;
    public int luck;
    public List<int> spellID;
    public string classText;

    public TheHero(float healthPoint, int attackPoint, int defencePoint, int luck, string classText, int card)
    {
        this.healthPoint = healthPoint;
        this.attackPoint = attackPoint;
        this.defencePoint = defencePoint;
        this.luck = luck;
        this.classText = classText;
        spellID = new List<int>();
        this.spellID.Add(card);
    }
    public override string ToString()
    {
        string cardsString = "-";
        foreach (var item in spellID)
        {
            cardsString += $"{item}-";
        }
        return $"hp:{healthPoint}, ap:{attackPoint}, dp:{defencePoint}, lp: {luck}, spell:{cardsString}, ct:{classText}";
    }
}

[Serializable]
public class ThePlayer: IComparable
{
    public string name;
    public int HP;
    public TheHero hero;

    public ThePlayer(string name, int hP, int card)
    {
        this.name = name;
        HP = hP;
        hero = new TheHero(Random.value, Random.Range(1, 10), Random.Range(1, 10), Random.Range(1, 10), Random.value.ToString(), card);
    }

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        if (obj is ThePlayer otherPlayer)
        {
            return name.CompareTo(otherPlayer.name);
        }
        else
        { 
            return -1;
        }
    }

    public override string ToString()
    {
        return $"N:{name}, HP:{HP}, Hero:{hero}";
    }
}
