using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

namespace ModularUtilityAI
{
    /// <summary>
    /// This class is responsible for evaluating all the actions assigned to it and performing the action with the best score
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class UtilityAI : MonoBehaviour
    {
        [NonSerialized]
        public NavMeshAgent agent;
        [Tooltip("If true, this AI will consider and perform actions")]
        public bool active = true;
        [Tooltip("A list of all actions that this AI should consider")]
        public List<AIAction> actions;
        
        Dictionary<AIAction, float> actionValues;

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            actionValues = new Dictionary<AIAction, float>();
        }

        // Update is called once per frame
        void Update()
        {
            if (active)
            {
                EvaluateActions()?.Do(this);
            }
        }

        public void Activate()
        {
            if (!active)
            {
                active = true;
            }
        }

        public void Deactivate()
        {
            if (active)
            {
                active = false;
                agent?.ResetPath();
            }
        }

        public AIAction EvaluateActions()
        {
            float bestScore = float.MinValue;
            AIAction bestAction = null;

            foreach (AIAction action in actions)
            {
                float score = action.Consider(this);
                actionValues[action] = score;
                if (score < 0)
                {
                    continue;
                }
                if (score > bestScore)
                {
                    bestScore = score;
                    bestAction = action;
                }
            }

            return bestAction;
        }
    }
}