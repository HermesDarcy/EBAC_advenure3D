using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(FSM_01))]
public class StateMachineEditor : Editor
{

    public bool showOut;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        FSM_01 fsm = (FSM_01)target;
        EditorGUILayout.LabelField(" States Machine");
        if (fsm.posStateMachine == null) return;
        
        if(fsm.posStateMachine.currentState != null)
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









/*
[CustomEditor(typeof(StateMachine))]
public class StateMachineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        StateMachine myTarget = (StateMachine)target;
        EditorGUILayout.HelpBox("teste " + myTarget.typeStates, MessageType.Info);
        
       

        if (GUILayout.Button(" Start State"))
        {
            myTarget.onStartGame();
        }

        if (GUILayout.Button(" Idle State"))
        {
            myTarget.onStateX();
        }

        if (GUILayout.Button(" Exit State"))
        {
            myTarget.onStateY();
        }


    }

}
*/
