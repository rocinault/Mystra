using System;

using UnityEngine;

using Golem;

namespace Mystra
{
    internal sealed class GameOverworldState<T> : State<T> where T : struct, IComparable, IConvertible, IFormattable
    {
        internal GameOverworldState(T uniqueId) : base(uniqueId)
        {

        }

        public override void Enter()
        {
            
        }
    }
}
