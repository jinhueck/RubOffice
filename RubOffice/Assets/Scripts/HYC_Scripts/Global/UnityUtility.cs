using UnityEngine;

public class UnityUtility : MonoBehaviour
{
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
