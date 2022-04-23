using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : IState
{
    protected int index;

    public int Index { get => index; set => index = value; }

    public abstract void ChooseMark(List<Mark> marks);
}
