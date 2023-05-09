using UnityEngine;

using Voltorb;

namespace Mystra
{
	internal sealed class SidebarMenu : Menu
	{
        public void OnOverworldButtonSelected()
        {
            GameCoordinator.instance.ChangeState(GameState.Overworld);
        }

        public void OnBattleButtonSelected()
        {
            GameCoordinator.instance.ChangeState(GameState.Battle);
        }

        public void OnOverviewButtonSelected()
        {

        }
    }
}
