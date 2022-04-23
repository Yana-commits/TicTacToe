using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultState : State
{
    private bool isFirst = true;
    private List<Mark> markNumbers = new List<Mark>();
    public override void ChooseMark(List<Mark> marks)
    {
        markNumbers.Clear();
        for (var i = 0; i < marks.Count; i++)
        {
            if (marks[i].CurMark == TicTacMark.None)
            {
                if (TryMark(i, PlayMode.AIs, marks))
                {
                    index = i;
                    Debug.Log("Bot");
                    marks[i].Score += -10;
                }
                else if (TryMark(i, PlayMode.Players, marks))
                {
                    index = i;
                    Debug.Log("Player");
                    marks[i].Score += -5;
                }
                else
                {
                    markNumbers.Add(marks[i]);
                    Debug.Log("Add");
                }
            }
        }
        if (isFirst)
        {
            index = RandomChoice.MarkIndex(markNumbers);
            isFirst = false;
        }
        else
        {
            index = FindLess(marks);
            foreach (var item in marks)
            {
                item.Score = 100;
            }
        }

        Debug.Log($"{index}");
    }
    private int FindLess(List<Mark> _marks)
    {
        int bestScore = 1000;
        int index = 0;
        for (var i = 0; i < _marks.Count; i++)
        {
            if (_marks[i].Score < bestScore)
            {
                bestScore = _marks[i].Score;
                index = i;
            }
        }
        return index;
    }
    private bool TryMark(int i, PlayMode mode, List<Mark> marks)
    {
        marks[i].CurMark = mode == PlayMode.AIs ? TicTacMark.O : TicTacMark.X;

        bool tryMark = new WinChecker(mode, marks).CheckIfWin();

        marks[i].CurMark = TicTacMark.None;
        return tryMark;
    }
}
