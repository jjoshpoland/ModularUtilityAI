using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ModularUtilityAI
{
    [Serializable]
    public class AIAction : ScriptableObject
    {
        public List<ConsiderationWeight> considerations;
        public virtual void Do(UtilityAI context)
        {

        }
        public float Consider(UtilityAI context)
        {
            float average = 0;
            foreach (ConsiderationWeight consideration in considerations)
            {
                float score = consideration.Evaluate(context);
                if (score < 0) return -1;
                average += score;
            }
            average = average / considerations.Count;
            return average;
        }
    }
}

