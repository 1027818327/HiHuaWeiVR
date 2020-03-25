using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR

namespace HVRCORE
{
    [CustomEditor(typeof(HvrAudioSource))]
    public class HvrAudioEditor : Editor
    {
        private SerializedObject mSerializedObj;
        //private SerializedProperty mHvrAudioType;
        private SerializedProperty mHvrOutVolume;
        private SerializedProperty mHvrMinDistance;
        private SerializedProperty mHvrMaxDistance;
        private SerializedProperty mHvrDoppler;
        private SerializedProperty mHvrRolloffMode;

        //private SerializedProperty mHvrReverbType;
        //private SerializedProperty mHvrAmbsonicFormat;
        void OnEnable() {
            mSerializedObj = new SerializedObject(target);
            //mHvrAudioType = mSerializedObj.FindProperty("AudioType");
            mHvrOutVolume = mSerializedObj.FindProperty("OutVolume");
            mHvrMinDistance = mSerializedObj.FindProperty("MinDistance");
            mHvrMaxDistance = mSerializedObj.FindProperty("MaxDistance");
            mHvrDoppler = mSerializedObj.FindProperty("Doppler");
            mHvrRolloffMode = mSerializedObj.FindProperty("RolloffMode");

            //mHvrReverbType = mSerializedObj.FindProperty("ReverbType");
            //mHvrAmbsonicFormat = mSerializedObj.FindProperty("AmbsonicFormat");
        }
        public override void OnInspectorGUI()
        {
            mSerializedObj.Update();
            HvrAudioSource source = (HvrAudioSource)target;
            //EditorGUILayout.PropertyField(mHvrAudioType);
			
            //if (HvrAudioSource.HvrAudioType.HVR_OBJECT_AUDIO == source.AudioType)
            {
				if (mHvrMinDistance.floatValue >= mHvrMaxDistance.floatValue) {
					mHvrMaxDistance.floatValue = mHvrMinDistance.floatValue + 1.0f;
				}
                EditorGUILayout.PropertyField(mHvrOutVolume);
                EditorGUILayout.PropertyField(mHvrMinDistance);
                EditorGUILayout.PropertyField(mHvrMaxDistance);
                EditorGUILayout.PropertyField(mHvrDoppler);
                EditorGUILayout.PropertyField(mHvrRolloffMode);
            }
            //else if (HvrAudioSource.HvrAudioType.HVR_CHANNEL_AUDIO == source.AudioType)
            //{
            //    EditorGUILayout.PropertyField(mHvrReverbType);
            //}
            //else {
            //    EditorGUILayout.PropertyField(mHvrAmbsonicFormat);
            //}
            mSerializedObj.ApplyModifiedProperties();
        }
    }
}
#endif