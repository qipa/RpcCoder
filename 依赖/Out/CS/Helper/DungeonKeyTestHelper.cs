#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;





public class DungeonKeyTestHelper : MonoBehaviour
{




}

[CustomEditor(typeof(DungeonKeyTestHelper))]
public class DungeonKeyTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        


    }

}
#endif