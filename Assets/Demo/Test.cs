
/// <summary>
/// Test.cs
/// </summary>
/// <remarks>
/// #CreateTime#: 创建. 陈伟超 <br/>
/// </remarks>

using UnityEngine;
using UnityEngine.UI;

namespace Demo
{
    public class Test : MonoBehaviour
    {
        #region Fields
        public GameObject audio3D;
        public GameObject audio2D;

        public Toggle mToggle;
        public Text mText;

        #endregion

        #region Properties

        #endregion

        #region Unity Messages
        //    void Awake()
        //    {
        //
        //    }
        //    void OnEnable()
        //    {
        //
        //    }
        //
        void Start()
        {
            mToggle.onValueChanged.AddListener(ChooseSwitch);
            Play3D();
        }
        //    
        //    void Update() 
        //    {
        //    
        //    }
        //
        //    void OnDisable()
        //    {
        //
        //    }
        //
        //    void OnDestroy()
        //    {
        //
        //    }

        #endregion

        #region Private Methods

        #endregion

        #region Protected & Public Methods
        void Play3D() 
        {
            mText.text = "当前播放3D音效";
            audio2D.SetActive(false);
            audio3D.SetActive(true);
        }

        void Play2D() 
        {
            mText.text = "当前播放2D音效";
            audio3D.SetActive(false);
            audio2D.SetActive(true);
        }

        public void ChooseSwitch(bool isChoose) 
        {
            if (isChoose)
            {
                Play3D();
            }
            else 
            {
                Play2D();
            }
        }
        #endregion
    }
}