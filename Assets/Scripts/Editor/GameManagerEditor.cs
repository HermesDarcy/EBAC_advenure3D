using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    
    
    public bool showOut;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GameManager fsm = (GameManager)target;
        EditorGUILayout.LabelField(" States Machine");
        if (fsm.posStateMachine == null) return;

        if (fsm.posStateMachine.currentState != null)
        {
            EditorGUILayout.LabelField(" On State", fsm.posStateMachine.currentState.ToString());
        }


        showOut = EditorGUILayout.Foldout(showOut, " type states");

        if (showOut && fsm.posStateMachine.dictStates != null)
        {
            var keys = fsm.posStateMachine.dictStates.Keys.ToArray();
            var vals = fsm.posStateMachine.dictStates.Values.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[i], vals[i]));
            }
        }

    }

    
}
