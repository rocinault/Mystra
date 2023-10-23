﻿using System.Collections;

using UnityEngine;

using Slowbro;

namespace Mystra
{
    internal sealed class LeftArrowBounce : MonoBehaviour
	{
        private RectTransform m_RectTransform;

        private RectTransform rectTransform
        {
            get
            {
                if (m_RectTransform == null)
                {
                    m_RectTransform = GetComponent<RectTransform>();
                }

                return m_RectTransform;
            }
        }

        private Vector2 m_DefaultPosition;

        private void Awake()
        {
            m_DefaultPosition = rectTransform.anchoredPosition;   
        }

        public void Play()
        {
            StartCoroutine(Animation());
        }

        private IEnumerator Animation()
        {
            while (true)
            {
                yield return rectTransform.Translate(rectTransform.anchoredPosition, Vector3.left, 0.75f, Space.Self, EasingType.PingPong);
            }
        }

        public void Stop()
        {
            rectTransform.anchoredPosition = m_DefaultPosition;

            StopAllCoroutines();
        }
    }
}
