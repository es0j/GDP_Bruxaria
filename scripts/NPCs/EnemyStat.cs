﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : CharacterStats
{
    public override void Die()
    {
        base.Die();
        MyEventSystem.instance.AddScoreCount();
        Destroy(gameObject);
    }
}
