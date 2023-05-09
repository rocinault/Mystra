using System;

using UnityEngine;

using Golem;

namespace Mystra
{
	internal sealed class BattleCoordinator : Singleton<BattleCoordinator>
	{
        [SerializeField]
        private SubMenu m_BattleSubMenu;

		private readonly StateMachine<BattleState> m_StateMachine = new StateMachine<BattleState>();

        protected override void Awake()
        {
            base.Awake();

            CreateStartupBattleStates();
        }

        private void CreateStartupBattleStates()
        {
            var states = new IState<BattleState>[]
            {
                new BattleBeginState<BattleState>(BattleState.Begin, this),
                new BattleWaitState<BattleState>(BattleState.Wait, this)
            };

            m_StateMachine.AddStatesToStateMachine(states);
        }

        private void OnEnable()
        {
            SetStateMachineID();
            StartStateMachine();
        }

        private void SetStateMachineID()
        {
            m_StateMachine.SetCurrentStateID(BattleState.Begin);
        }

        private void StartStateMachine()
        {
            m_StateMachine.Start();
        }

        private void OnDisable()
        {
            m_StateMachine.Stop();
        }

        internal void ChangeState(BattleState stateToTransitionInto)
        {
            m_StateMachine.ChangeState(stateToTransitionInto);
        }

        internal void ShowBattleSubMenu()
        {
            m_BattleSubMenu.Show();
        }
    }

    internal sealed class BattleBeginState<T> : State<T> where T : struct, IComparable, IConvertible, IFormattable
    {
        private readonly BattleCoordinator m_Coordinator;

        internal BattleBeginState(T uniqueId, BattleCoordinator coordinator) : base(uniqueId)
        {
            m_Coordinator = coordinator;
        }

        public override void Enter()
        {
            Debug.Log("entered battle begin state");

            m_Coordinator.ChangeState(BattleState.Wait);
        }
    }

    internal sealed class BattleWaitState<T> : State<T> where T : struct, IComparable, IConvertible, IFormattable
    {
        private readonly BattleCoordinator m_Coordinator;

        internal BattleWaitState(T uniqueId, BattleCoordinator coordinator) : base(uniqueId)
        {
            m_Coordinator = coordinator;
        }

        public override void Enter()
        {
            Debug.Log("entered battle wait state");

            m_Coordinator.ShowBattleSubMenu();
        }
    }
}
