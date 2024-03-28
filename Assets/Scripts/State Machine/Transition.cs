using System;

public class Transition
{
    public IState ToState;
    public Func<bool> Condition;

    public Transition(IState toState, Func<bool> condition)
    {
        ToState = toState;
        Condition = condition;
    }
}
