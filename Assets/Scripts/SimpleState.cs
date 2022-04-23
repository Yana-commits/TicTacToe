using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleState : State
{
    private List<Mark> noneMarks = new List<Mark>();
    public override void ChooseMark(List<Mark> marks)
    {
        noneMarks = marks.Where(x => x.CurMark == TicTacMark.None).ToList();

        index = RandomChoice.MarkIndex(noneMarks);
    }
}
