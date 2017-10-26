#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;





public class OnlineDataTestHelper : MonoBehaviour
{




}

[CustomEditor(typeof(OnlineDataTestHelper))]
public class OnlineDataTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        


    }

}
#endif