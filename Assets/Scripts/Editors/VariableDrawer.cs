#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Randomization;

[CustomPropertyDrawer(typeof(VariableInt)), CustomPropertyDrawer(typeof(VariableFloat))]
public class VariableDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty generationMethod = property.FindPropertyRelative("VariableType");
        VariableType variableType = (VariableType)generationMethod.enumValueIndex;
        
        Rect singleFieldRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

        // Always draw generation method field
        EditorGUI.PropertyField(singleFieldRect, generationMethod, new GUIContent(property.displayName));
        
        singleFieldRect.y += EditorGUIUtility.singleLineHeight;

        switch(variableType)
        {
            case VariableType.Fixed:
                EditorGUI.PropertyField(singleFieldRect, property.FindPropertyRelative("FixedValue"), new GUIContent("   Fixed Value"));
                break;
            case VariableType.ConstRandom:
                EditorGUI.PropertyField(singleFieldRect, property.FindPropertyRelative("MinValue"), new GUIContent( "   Min Value"));
                singleFieldRect.y += EditorGUIUtility.singleLineHeight;
                EditorGUI.PropertyField(singleFieldRect, property.FindPropertyRelative("MaxValue"), new GUIContent("   Max Value"));
                break;
        }
        EditorGUI.EndProperty();
    }
    
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        VariableType variableType = (VariableType)property.FindPropertyRelative("VariableType").enumValueIndex;
        switch (variableType)
        {
            case VariableType.Fixed:
                return EditorGUIUtility.singleLineHeight * 2;
            case VariableType.ConstRandom:
                return EditorGUIUtility.singleLineHeight * 4;
            default:
                return base.GetPropertyHeight(property, label);
        }
    }
}
#endif