using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinChecker
{
    private TicTacMark currentMark = TicTacMark.None;
    private List<Mark> marks = new List<Mark>();

    public WinChecker(PlayMode mode, List<Mark> _marks )
    {
        currentMark = mode == PlayMode.Players ? TicTacMark.X : TicTacMark.O;
        marks = _marks;
    }
    public bool CheckIfWin()
    {
        return
        AreMatched(0, 1, 2) || AreMatched(3, 4, 5) || AreMatched(6, 7, 8) ||
             AreMatched(0, 3, 6) || AreMatched(1, 4, 7) || AreMatched(2, 5, 8) ||
              AreMatched(0, 4, 8) || AreMatched(2, 4, 6);
    }
    private bool AreMatched(int i,int j,int k)
    {
        bool matched = (marks[i].CurMark == currentMark && marks[j].CurMark == currentMark && marks[k].CurMark == currentMark);
        return matched;
    }

}
