#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;





public class ActivityPlayTestHelper : MonoBehaviour
{




}

[CustomEditor(typeof(ActivityPlayTestHelper))]
public class ActivityPlayTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        


    }

}
#endif