#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;





public class BagRecycleTestHelper : MonoBehaviour
{




}

[CustomEditor(typeof(BagRecycleTestHelper))]
public class BagRecycleTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        


    }

}
#endif