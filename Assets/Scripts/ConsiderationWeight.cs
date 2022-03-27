using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModularUtilityAI
{
    /// <summary>
    /// This class is used to uniquely evalute a consideration based on an assigned curve
    /// </summary>
    [System.Serializable]
    public class ConsiderationWeight
    {
        [Tooltip("This should be normalized from 0-1 for t. The value of the consideration is the input of t and evaluated at that point on the curve.")]
        public AnimationCurve curve;
        [Tooltip("The weight of the consideration after being evaluated against the curve")]
        [Range(0f,1f)]
        public float weight;
        [Tooltip("The consideration to be evaluated")]
        public AIConsideration consideration;

        /// <summary>
        /// Given an AI for context, the consideration assigned to this object will be evaluated against curve and weight, in that order, to return a normalized score of 0-1. If a negative value is returned, the consideration is invalid and cannot succeed.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public float Evaluate(UtilityAI context)
        {
            float considerationScore = consideration.Consider(context);
            if (considerationScore < 0f)
            {
                //Debug.Log(consideration.name + " returned value of " + considerationScore);
                return -1f;
            }

            considerationScore = curve.Evaluate(considerationScore);
            considerationScore *= weight;
            return considerationScore;
        }
    }
}

