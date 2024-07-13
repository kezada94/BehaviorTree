using UnityEditor;
using UnityEngine;

namespace RR.Serialization.Editor
{
    [CustomPropertyDrawer(typeof(ReadonlyVar<>))]
    public class ReadonlyVarDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty value = Value(property);

            EditorGUI.PropertyField(
                position, 
                value, 
                new GUIContent(property.displayName), 
                true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {   
            var propHeight = base.GetPropertyHeight(property, label);
            var value = Value(property);

            if (!value.hasChildren)
            {
                return propHeight;
            }

            if (value.isArray)
            {
                var nArrChildren = value.arraySize;
                return nArrChildren == 0 
                    ? propHeight * 4 
                    : propHeight * 3 + ((propHeight + 2f) * nArrChildren);
            }

            var nChildren = PropertyDrawerUtility.GetChildrenSize(value);
            return (propHeight + 2f) * nChildren;
        }

        private SerializedProperty Value(SerializedProperty property) => property.FindPropertyRelative("_value");
    }
}
