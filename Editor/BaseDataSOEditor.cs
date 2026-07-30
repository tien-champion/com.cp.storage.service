using UnityEditor;
using UnityEngine;

namespace Champion
{
    [CustomEditor(typeof(BaseDataSO), true)]
    public class BaseDataSOEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawPropertiesWithSeparator();

            GUILayout.Space(10);

            BaseDataSO dataSo = (BaseDataSO)target;

            GUILayout.Space(5);

            if (GUILayout.Button("Save", GUILayout.Height(25)))
            {
                dataSo.Save();
                EditorUtility.SetDirty(dataSo);
                Debug.Log("[BaseDataSO] Saved");
            }

            if (GUILayout.Button("Load", GUILayout.Height(25)))
            {
                dataSo.Load();
                EditorUtility.SetDirty(dataSo);
                Debug.Log("[BaseDataSO] Loaded");
            }

            if (GUILayout.Button("Reset", GUILayout.Height(25)))
            {
                dataSo.ResetData();
                EditorUtility.SetDirty(dataSo);
                Debug.Log("[BaseDataSO] Reset!");
            }

            if (GUILayout.Button("Setup Test", GUILayout.Height(25)))
            {
                dataSo.SetupTest();
                EditorUtility.SetDirty(dataSo);
                Debug.Log("[BaseDataSO] Setup Test applied");
            }

            if (GUILayout.Button("Delete", GUILayout.Height(25)))
            {
                if (EditorUtility.DisplayDialog(
                        "Delete Save Data",
                        "Are you sure you want to delete player save?",
                        "Yes",
                        "Cancel"))
                {
                    dataSo.Delete();
                    Debug.Log("[BaseDataSO] Deleted");
                }
            }

            if (GUILayout.Button("Open Save Folder", GUILayout.Height(25)))
            {
                EditorUtility.RevealInFinder(Application.persistentDataPath);
            }

            GUILayout.Space(5);
            EditorGUILayout.HelpBox(
                "Persistent Path:\n" + Application.persistentDataPath,
                MessageType.Info);
        }

        private void DrawPropertiesWithSeparator()
        {
            serializedObject.Update();

            SerializedProperty property = serializedObject.GetIterator();
            bool enterChildren = true;
            bool separatorDrawn = false;

            while (property.NextVisible(enterChildren))
            {
                enterChildren = false;

                if (!separatorDrawn && property.name == "_Default")
                {
                    DrawSeparator();
                    separatorDrawn = true;
                }

                using (new EditorGUI.DisabledScope(property.propertyPath == "m_Script"))
                {
                    EditorGUILayout.PropertyField(property, true);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawSeparator()
        {
            GUILayout.Space(6);
            Rect rect = EditorGUILayout.GetControlRect(false, 1);
            EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
            GUILayout.Space(4);
        }
    }
}