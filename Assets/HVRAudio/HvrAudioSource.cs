using UnityEngine;
using System.Collections;

namespace HVRCORE
{
    public class HvrAudioSource : MonoBehaviour
    {
        //public enum HvrAudioType
        //{
        //    HVR_OBJECT_AUDIO,
        //    HVR_CHANNEL_AUDIO,
        //    HVR_AMBSONIC_AUDIO
        //}

        public enum HvrReverbType {
            HVR_REVERB_NONE,
            HVR_REVERB_MODEL,
            HVR_REVERB_LIVING_ROOM,
            HVR_REVERB_LISTENING_ROOM,
            HVR_REVERB_THEATER_A,
            HVR_REVERB_THEATER_B,
            HVR_REVERB_CHURCH
        }

        public enum HvrAmbsonicFormat {
            HVR_AMBSONIC_ACN,
            HVR_AMBSONIC_FUMA,
            HVR_AMBSONIC_FORMCH
        }
        
        //public HvrAudioType AudioType = HvrAudioType.HVR_OBJECT_AUDIO;

        [SerializeField(), Range(0.0f, 100.0f)]
        public float OutVolume = 100.0f;

        [SerializeField(), Range(0.0f, 999.0f)]
        public float MinDistance = 1.0f;

        [SerializeField(), Range(0.0f, 1000.0f)]
        public float MaxDistance = 1000.0f;

        public bool Doppler = true;

        public enum HvrRolloffMode
        {
            HVR_ROLLOFF_INVERSE,  //倒数衰减
            HVR_ROLLOFF_LINEAR,
            HVR_ROLLOFF_EXPONENTIAL
        }
        public HvrRolloffMode RolloffMode = HvrRolloffMode.HVR_ROLLOFF_INVERSE;

        public HvrReverbType ReverbType = HvrReverbType.HVR_REVERB_MODEL;

        public HvrAmbsonicFormat AmbsonicFormat = HvrAmbsonicFormat.HVR_AMBSONIC_ACN;

        private void Awake()
        {
            var audioSource = GetComponent<AudioSource>();
            if (null == audioSource)
            {
                Debug.LogError("HVR Error, Failed to Get AudioSource");
                return;
            }
            SetSpatializerParam(ref audioSource);
        }

        public void SetSpatializerParam(ref AudioSource audioSource)
        {
            //audioSource.SetSpatializerFloat(2, (float)AudioType);
			//AudioType = HvrAudioType.HVR_OBJECT_AUDIO;
            //if (HvrAudioType.HVR_OBJECT_AUDIO == AudioType) 
			{
                audioSource.SetSpatializerFloat(5, OutVolume);
                audioSource.SetSpatializerFloat(6, MinDistance);
                audioSource.SetSpatializerFloat(7, MaxDistance);
                if (Doppler)
                {
                    audioSource.SetSpatializerFloat(8, 1.0f);
                }
                else
                {
                    audioSource.SetSpatializerFloat(8, 0.0f);
                }
                audioSource.SetSpatializerFloat(9, (float)RolloffMode);
				

            } 
			//else if (HvrAudioType.HVR_CHANNEL_AUDIO == AudioType) {
            //    audioSource.SetSpatializerFloat(4, (float)ReverbType);
            //} else {
            //    audioSource.SetSpatializerFloat(3, (float)AmbsonicFormat);
            //}
        }
    }
}