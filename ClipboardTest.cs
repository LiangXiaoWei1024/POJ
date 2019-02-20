using UnityEngine;
using System.Collections;
using System.Xml.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClipboardTest : MonoBehaviour
{
    private AndroidJavaObject activity;

    public Text text;
    // Use this for initialization
    void Start ()
    {
        text.text = "我爱国！";

#if UNITY_ANDROID
  
        activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        if (activity == null)
            return ;

#endif
    }

    public void Copy()
    {
        // 复制到剪贴板
        using (AndroidJavaClass clipboard = new AndroidJavaClass("com.zdf.JarDemo"))
        {
            Debug.Log("--copy--");
            clipboard.CallStatic("copyTextToClipboard", activity, "I love You");
            //clipboard.Call("copyTextToClipboard", activity, );
        }
    }

    public void Paste()
    {
        // 从剪贴板中获取文本
        using (AndroidJavaClass clipboard = new AndroidJavaClass("com.zdf.JarDemo"))
        {
            string text1 = clipboard.CallStatic<string>("getTextFromClipboard");//clipboard.Call<string>("getTextFromClipboard");
            Debug.Log("Paste text is : " + text1);
            text.text = text1;
        }   
    }
}
