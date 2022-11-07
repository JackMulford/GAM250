using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[System.Serializable]
public class FungusString{
   public string variableName;
   [TextArea]
   public string content;
}

[CreateAssetMenu]
public class QuestText : ScriptableObject
{
    [SerializeField]
    List<FungusString> fungusValues = new List<FungusString>();
 
    public void SetQuestText(Flowchart flowchart)
    {
        for (int i = 0; i < fungusValues.Count; i++)
        {
            flowchart.SetStringVariable(fungusValues[i].variableName, fungusValues[i].content);
        }
    }
}
