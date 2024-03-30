using System;

namespace InfrastructureLogic.StateMachineLogic.Simple
{
    public class SimpleStateMachine<State> : StateMachine<State> where State : Enum
    {
        private ISimpleState<State> _currentTypedState;
        
        public override void Initialize(State initialState)
        {
            _currentTypedState = GetState<ISimpleState<State>>(initialState);
            _currentTypedState.Enter();
            SetCurrentState(_currentTypedState);
        }

        public override void TransitToState(State nextStateKey)
        {
            if (_currentTypedState != null)
            {
                if (nextStateKey.Equals(_currentTypedState.StateKey)) return;
                 _currentTypedState.Exit();
            }
            
            _currentTypedState = GetState<ISimpleState<State>>(nextStateKey);
            _currentTypedState.Enter();
            SetCurrentState(_currentTypedState);
        }
    }
}