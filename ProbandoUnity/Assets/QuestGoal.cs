using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public int requisitoMision;
    public int currentAmount;
    public GameObject objetoBorrar;
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
    public void Hablar()
    {
        if (goalType == GoalType.Hablar)
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
