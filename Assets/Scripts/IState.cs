

using System.Collections.Generic;

public interface IState
{
    void ChooseMark(List<Mark> marks);

    int Index { get; set; }
}
