using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModularUtilityAI
{
    [RequireComponent(typeof(Animator), typeof(UtilityAI))]
    public class AIAnimatorSync : MonoBehaviour
    {
        Animator animator;
        UtilityAI utilityAI;
        Vector3 lastPos;
        // Start is called before the first frame update
        void Start()
        {
            utilityAI = GetComponent<UtilityAI>();
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (animator == null) return;
            Vector3 movementDelta = transform.InverseTransformPoint(lastPos);

            float newVert = -1f * movementDelta.z / Time.deltaTime / utilityAI.agent.speed;
            float newHorz = -1f * movementDelta.x / Time.deltaTime / utilityAI.agent.speed;
            lastPos = transform.position;
            animator.SetFloat("Vertical", newVert);
            animator.SetFloat("Horizontal", newHorz);
        }
    }
}