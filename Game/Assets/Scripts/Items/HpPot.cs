﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HpPot", menuName = "Items/HpPot", order = 2)]
public class HpPot : Item,IUse
{
    [SerializeField]
    private float heal;
    public void Use()
    {
        Remove();
        PlayerStats.Instance.CurrentHealth += heal;
    }


}