using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModularUtilityAI
{
    public class AttackAction : AIAction
    {
        public float Range;
        public int BaseDamage;
        public float Cooldown;


        public override void Do(UtilityAI context)
        {
            if(context.parameters.TryGetValue("LastAttack", out float lastAttack))
            {
                if(Time.time < lastAttack + Cooldown)
                {
                    return;
                }
            }

            Collider[] targets = Physics.OverlapSphere(context.transform.position, Range);
            Health closestTarget = null;
            float closestDist = float.MaxValue;
            if(targets.Length > 0)
            {
                for (int i = 0; i < targets.Length; i++)
                {
                    float distance = Vector3.Distance(targets[i].transform.position, context.transform.position);
                    if (distance < closestDist)
                    {
                        closestDist = distance;
                        closestTarget = targets[i];
                    }
                }
            }
        }

    }
}