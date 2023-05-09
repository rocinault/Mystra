using System;

using UnityEngine;

using Golem;

namespace Mystra
{
    internal sealed class GameBattleState<T> : State<T> where T : struct, IComparable, IConvertible, IFormattable
    {
        internal GameBattleState(T uniqueId) : base(uniqueId)
        {

        }
    }
}
