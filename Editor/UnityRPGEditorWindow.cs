using Sirenix.OdinInspector.Editor;
using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using Sirenix.OdinInspector;


namespace UnityRPGEditor.Editor
{
    public class UnityRPGEditorWindow : OdinMenuEditorWindow //OdinMenuEditorWindow creates a list of editable assets in a new window
    {
        [MenuItem("Tools/RPG Editor Window")] //MenuItem adds our static function to Unity editor Windows
        private static void OpenEditor()
        {
            GetWindow<UnityRPGEditorWindow>(); //GetWindow will create a window using the selected type
        }
        protected override OdinMenuTree BuildMenuTree()
        {
            OdinMenuTree tree = new OdinMenuTree(); //create a new tree to display

            List<Type> includedTypes = new List<Type>();
            includedTypes.Add(typeof(CharacterData));
            includedTypes.Add(typeof(ClassData));
            includedTypes.Add(typeof(WeaponData));
            includedTypes.Add(typeof(SkillData));

            foreach (Type type in includedTypes) // add items to tree
            {
                tree.AddAllAssetsAtPath(type.Name, "Assets/", type, true, false);
                tree.Add("New " + type.Name, new CreateNewAsset(type));
                
            }


            return tree;
        }

        //called during drawing step after tree is created
        protected override void OnBeginDrawEditors()
        {
            base.OnBeginDrawEditors();

            MenuTree.DrawSearchToolbar();

        }
    }

    public class CreateNewAsset
    {
        private Type _type;
       [SerializeField, InlineEditor(Expanded = true)] private ScriptableObject _data;

        [field: SerializeField]
        public string Name { get; private set; } = "New Data";

        public CreateNewAsset(Type type)
        {
            _type = type;
            _data = ScriptableObject.CreateInstance(_type);
        }

        [Button("Create New")]
        private void CreateNew()
        {
            string path = GetProjectWindowPath();
            AssetDatabase.CreateAsset(_data, path + Name + ".asset");
            AssetDatabase.SaveAssets();

        }

        //get active folder path from unity editor, this is normally an internal function, so we use reflection to call it anyway
        private string GetProjectWindowPath()
        {
            //use reflection to analyze a class, find a specific private function and call it
            //we do this to gain editor functionality we dont normally have access to

            Type projectWindowUtilType = typeof(ProjectWindowUtil);
            MethodInfo getActiveFolderPath = projectWindowUtilType.GetMethod("GetActiveFolderPath", BindingFlags.Static | BindingFlags.NonPublic);
            object obj = getActiveFolderPath.Invoke(null, new object[0]);
            string path = obj.ToString() + "/";
            return path;
        }
    }
}
