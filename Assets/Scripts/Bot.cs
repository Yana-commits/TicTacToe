using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bot 
{
    private State state;
    public int index;

    public Bot(State _state)
    {
        state = _state;
    }
    public void ChooseMark(List<Mark> marks)
    {
        state.ChooseMark(marks);

        index = state.Index;
    }
}
