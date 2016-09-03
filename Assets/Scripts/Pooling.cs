using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pooling : MonoBehaviour {

    public static List<GameObject> miceList = new List<GameObject>();

    public static void Init() {
        miceList.Clear();
    }

    /// <summary>

    /// Pooling function, should replace Instantiate

    /// </summary>

    /// <param name="name">Destination path in Resources folder</param>

    /// <param name="position">Position of the spawned object</param>

    /// <param name="rotation">Rotation of the spawned object</param>

    /// <param name="goList">Pooling List</param>

    /// <returns></returns>

    public static GameObject SpawnObject(string name, Vector2 position, Quaternion rotation, List<GameObject> goList)
    {
        GameObject newGO = null;
        bool isInstantiate = false;

        foreach (GameObject s in goList)
        {
            s.transform.position = position;
            s.transform.rotation = rotation;
            isInstantiate = true;
            newGO = s;

            goList.Remove(s);

            break;
        }

        if (!isInstantiate)
            newGO = (GameObject)Instantiate(Resources.Load(name), position, rotation);

        newGO.SetActive(true); //in case the GO comes from a cemetery

        return newGO;
    }
}
