using UnityEngine;

public class UnityUtility : MonoBehaviour
{
    public bool IsAndroid()
    {
        if (Application.platform == RuntimePlatform.Android &&
            Application.platform != RuntimePlatform.OSXEditor &&
            Application.platform != RuntimePlatform.WindowsEditor)
            return true;
        return false;
    }

    public T ParserJsonToObject<T>(string strJson)
    {
        return JsonUtility.FromJson<T>(strJson);
    }
    /// <summary> 자식 오브젝트 전부 Destroy</summary>
    public void DestroyChildObject(GameObject parent)
    {
        GameObject[] childs = parent.GetChildsObject();
        foreach (GameObject i in childs)
        {
            Destroy(i);
        }
    }
}
