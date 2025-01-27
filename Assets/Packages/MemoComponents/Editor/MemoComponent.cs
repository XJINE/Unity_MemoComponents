// CAUTION:
// If you set the assembly definition to EditorOnly,
// it will no longer be able to attach the MemoComponent.
// And, simply placing it in the Editor folder will cause problems.
// "#if UNITY_EDITOR" is necessary.
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class MemoComponent : MonoBehaviour
{
    [Multiline][SerializeField] private string memo;

    public void OnDrawGizmos()
    {
        Handles.BeginGUI();
        Handles.Label(transform.position, string.IsNullOrWhiteSpace(memo) ? name : memo);
        Handles.EndGUI();
    }

    [CanEditMultipleObjects]
    [CustomEditor(typeof(MemoComponent))]
    public class NoteComponentEditor : Editor
    {
        private SerializedProperty _memoProperty;

        #region Method

        private void OnEnable()
        {
            _memoProperty = base.serializedObject.FindProperty(nameof(memo));
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_memoProperty, GUIContent.none);

            serializedObject.ApplyModifiedProperties();
        }

        #endregion Method
    }
}
#endif // UNITY_EDITOR