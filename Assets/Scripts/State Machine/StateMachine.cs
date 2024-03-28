using System;
using System.Collections.Generic;

public class StateMachine
{
    private IState currentState;
    private Dictionary<IState, List<Transition>> transitions = new Dictionary<IState, List<Transition>>();
    private List<Transition> anyTransitions = new List<Transition>();
    private List<Transition> emptyTransitions = new List<Transition>();
    private List<Transition> currentTransitions = new List<Transition>();
    private Transition nextTransition = null;

    public void SetState(IState newState)
    {
        if (currentState == newState) return;
        
        currentState?.OnExit();

        currentState = newState;
        currentTransitions = transitions[currentState] != null ? transitions[currentState] : emptyTransitions;

        currentState.OnEnter();
    }

    public void AddTransition(IState fromState, IState toState, Func<bool> condition)
    {
        if (transitions[fromState] == null)
        {
            transitions[fromState] = new List<Transition>();
        }

        transitions[fromState].Add(new Transition(toState, condition));
    }

    public void AddAnyTransition(IState state, Func<bool> condition)
    {
        anyTransitions.Add(new Transition(state, condition));
    }

    public void Tick()
    {
        nextTransition = GetTransition();
        if (nextTransition != null)
        {
            SetState(nextTransition.ToState);
            return;
        }

        currentState?.Tick();
    }

    private Transition GetTransition()
    {
        foreach (var transition in anyTransitions)
        {
            if (transition.Condition())
            {
                return transition;
            }
        }

        foreach (var transition in currentTransitions)
        {
            if (transition.Condition())
            {
                return transition;
            }
        }

        return null;
    }
}
