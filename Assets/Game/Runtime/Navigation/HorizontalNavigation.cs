using UnityEngine;
using UnityEngine.EventSystems;
using Voltorb;

namespace Mystra
{
	internal sealed class HorizontalNavigation : SelectableNavigation
	{
        public override void OnSubmit(BaseEventData eventData)
        {
            m_Selectables[m_SelectedIndex].Select();
        }

        protected override void OnMoveLeft(AxisEventData eventData)
        {
            int index = Mathf.Clamp(m_SelectedIndex - 1, 0, m_Selectables.Length - 1);

            if (IsTargetSelectableInteractable(index))
            {
                m_Selectables[m_SelectedIndex].OnDeselect(eventData);
                m_SelectedIndex = index;
                m_Selectables[m_SelectedIndex].OnSelect(eventData);
            }
        }

        protected override void OnMoveRight(AxisEventData eventData)
        {
            int index = Mathf.Clamp(m_SelectedIndex + 1, 0, m_Selectables.Length - 1);

            if (IsTargetSelectableInteractable(index))
            {
                m_Selectables[m_SelectedIndex].OnDeselect(eventData);
                m_SelectedIndex = index;
                m_Selectables[m_SelectedIndex].OnSelect(eventData);
            }
        }
    }
}
