using UnityEditor;

namespace RR.Serialization.Editor
{
    public static class PropertyDrawerUtility
    {
        public static int GetChildrenSize(SerializedProperty property, string propName)
        {
            var child = property.FindPropertyRelative(propName);

            System.Func<SerializedProperty, string, int> CountChildren = (property, propName) =>
            {
                int cnt = 0;

                foreach (var _ in property.FindPropertyRelative(propName))
                {
                    cnt++;
                }

                return cnt;
            };

            var childrenSize = child.isArray ? child.arraySize : CountChildren(property, propName);
            return childrenSize == 0 ? 1 : childrenSize;
        }

        public static int GetChildrenSize(SerializedProperty property)
        {
            if (!property.hasChildren)
            {
                return 1;
            }

            if (property.isArray)
            {
                return property.isExpanded ? property.arraySize : 1;
            }       

            if (!property.isExpanded)
            {
                return 1;
            }

            SerializedProperty clone = property.Copy();

            return clone.CountInProperty();
        }
    }
}