using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModularUtilityAI
{
    /// <summary>
    /// This abstract class should be extended to consider any desired aspect of a provided AI context.
    /// When extending, be sure to add a CreateAssetMenu tag to the child class to create and manipulate the scriptable object in the editor.
    /// </summary>
    public abstract class AIConsideration : ScriptableObject
    {
        public abstract float Consider(UtilityAI context);
    }
}