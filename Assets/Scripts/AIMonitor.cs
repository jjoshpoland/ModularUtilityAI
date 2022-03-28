using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ModularUtilityAI
{
    public class AIMonitor : MonoBehaviour
    {
        public UtilityAI utilityAI;
        public TMP_Text actionTextPrefab;
        public Transform actionTextBox;
        List<TMP_Text> actionTexts;
        // Start is called before the first frame update
        void Start()
        {
            if(utilityAI != null)
            {
                Init(utilityAI);
            }
        }

        public void Init(UtilityAI AI)
        {
            Clear();
            utilityAI = AI;
            foreach(AIAction action in utilityAI.actions)
            {
                TMP_Text actionText = Instantiate(actionTextPrefab, actionTextBox);
                actionText.text = action.name + " " + utilityAI.GetActionValue(action);
                actionTexts.Add(actionText);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if(utilityAI == null)
            {
                return;
            }
            for (int i = 0; i < actionTexts.Count; i++)
            {
                actionTexts[i].text = utilityAI.actions[i].name + utilityAI.GetActionValue(utilityAI.actions[i]);
            }
        }

        public void Clear()
        {
            //List<Transform> textsToDelete = new List<Transform>();
            foreach(Transform t in actionTextBox)
            {
                Destroy(t.gameObject);
            }
            actionTexts = new List<TMP_Text>();
        }
    }
}