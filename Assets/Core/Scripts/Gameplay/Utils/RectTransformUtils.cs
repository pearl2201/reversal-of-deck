using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReversalOfSpirit
{
    public static class RectTransformUtils
    {
        /// <summary>
        /// Converts the anchoredPosition of the first RectTransform to the second RectTransform,
        /// taking into consideration offset, anchors and pivot, and returns the new anchoredPosition
        /// </summary>
        public static Vector2 SwitchToRectTransform(RectTransform from, RectTransform to)
        {
            Vector2 fromPivotDerivedOffset = new Vector2(from.rect.width * from.pivot.x + from.rect.xMin, from.rect.height * from.pivot.y + from.rect.yMin);
            Vector2 screenP = RectTransformUtility.WorldToScreenPoint(null, from.position);
            screenP += fromPivotDerivedOffset;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(to, screenP, null, out Vector2 localPoint);
            Vector2 pivotDerivedOffset = new Vector2(to.rect.width * to.pivot.x + to.rect.xMin, to.rect.height * to.pivot.y + to.rect.yMin);
            return to.anchoredPosition + localPoint - pivotDerivedOffset;
        }
    }
}
