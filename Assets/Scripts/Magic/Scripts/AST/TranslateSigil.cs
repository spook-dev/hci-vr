﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateSigil : Statement
{
    //public bool updateAfterTranslation;
    public NumberArgument x;
    public NumberArgument y;
    public NumberArgument z;
    public TranslateSigil(GameObject Model) : base(Model)
    {
    }
    public TranslateSigil(GameObject Model, float xv, float yv, float zv) : base(Model)
    {
        x.SetValue(xv);
        y.SetValue(yv);
        z.SetValue(zv);
    }

    public override bool Invoke()
    {
        if (!receivingFromOwnBreak)
        {
            receivingFromOwnBreak = true;
            return true;
        }
        Debug.Log("Invoke TranslateSigil");
        Shard s = FindShard();
        if(s is null)
        {
            Debug.Log("Couldn't find Shard for instruction :(");
        }
        s.Move(new Vector3(x.Value, y.Value, z.Value));
        Debug.Log("Moving shard to " + s.transform.Find("Model").position.ToString());
        return false;
    }
}