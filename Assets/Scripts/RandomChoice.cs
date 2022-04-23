using System.Collections.Generic;

public static class RandomChoice
{
    public static int MarkIndex(List<Mark> marks)
    {
        System.Random choice = new System.Random();
        var mark = marks[choice.Next(0, marks.Count)];
        int index = mark.Index;
        return index;
    }
}
