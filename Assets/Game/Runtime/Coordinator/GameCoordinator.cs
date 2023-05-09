using UnityEngine;

using Golem;

namespace Mystra
{
	internal sealed class GameCoordinator : Singleton<GameCoordinator>
	{
        private StateMachine<GameState> m_StateMachine = new StateMachine<GameState>();

        protected override void Awake()
        {
            base.Awake();

            CreateStartupGameStates();
        }

        private void CreateStartupGameStates()
        {
            var states = new IState<GameState>[]
            {
                new GameOverworldState<GameState>(GameState.Overworld),
                new GameBattleState<GameState>(GameState.Battle)
            };

            m_StateMachine.AddStatesToStateMachine(states);
        }

        private void Start()
        {
            SetStateMachineID();
            StartStateMachine();
        }

        private void SetStateMachineID()
        {
            m_StateMachine.SetCurrentStateID(GameState.Battle);
        }

        private void StartStateMachine()
        {
            m_StateMachine.Start();
        }

        internal void ChangeState(GameState stateToTransitionInto)
        {
            m_StateMachine.ChangeState(stateToTransitionInto);
        }
    }
}
