using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public int requisitoMision;
    public int currentAmount;
    public bool IsReached()
    {
        return (currentAmount >= requisitoMision);
    }
    public void CojerMonedas()
    {
        if (goalType == GoalType.CojerMonedas)
        {
            currentAmount++;
        }
    }
}
public enum GoalType
{
    CojerMonedas,
    Hablar
}
