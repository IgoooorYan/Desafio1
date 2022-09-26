using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameController : MonoBehaviour
{
    public string SaveFilePath { get => $"{Application.persistentDataPath}/save.json"; }
    public List<ObjectSaveDTO> objectSave = new List<ObjectSaveDTO>();
    public List<ObjectClassPt> primitive = new List<ObjectClassPt>();
    public List<ObjectClassPf> prefab = new List<ObjectClassPf>();
    public List<ObjectClassGo> gameobject = new List<ObjectClassGo>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ObjectSaveToJson();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadObjectSave();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ObjectCreate();
        }
    }

    private void ObjectCreate()
    {
        ObjectSaveDTO saveDTO = new ObjectSaveDTO();

        for (int i = 0; i < 1; i++)
        {
            var C = UnityEngine.Random.Range(0f, 1f);
            var O = UnityEngine.Random.Range(0f, 1f);
            var R = UnityEngine.Random.Range(0f, 1f);
            var corPt = new Color(C, O, R);

            var C1 = UnityEngine.Random.Range(0f, 1f);
            var O1 = UnityEngine.Random.Range(0f, 1f);
            var R1 = UnityEngine.Random.Range(0f, 1f);
            var corPf = new Color(C1, O1, R1);

            var C2 = UnityEngine.Random.Range(0f, 1f);
            var O2 = UnityEngine.Random.Range(0f, 1f);
            var R2 = UnityEngine.Random.Range(0f, 1f);
            var corGo = new Color(C2, O2, R2);

            Vector3 posPt = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), UnityEngine.Random.Range(-5.0f, 7.0f), 0);
            Vector3 posPf = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), UnityEngine.Random.Range(-5.0f, 7.0f), 0);
            Vector3 posGo = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), UnityEngine.Random.Range(-5.0f, 7.0f), 0);

            Vector3 sclPt = new Vector3(UnityEngine.Random.Range(1f, 3f), UnityEngine.Random.Range(1f, 3.0f), UnityEngine.Random.Range(1f, 3f));
            Vector3 sclPf = new Vector3(UnityEngine.Random.Range(1f, 3f), UnityEngine.Random.Range(1f, 3.0f), UnityEngine.Random.Range(1f, 3f));
            Vector3 sclGo = new Vector3(UnityEngine.Random.Range(1f, 3f), UnityEngine.Random.Range(1f, 3.0f), UnityEngine.Random.Range(1f, 3f));

            Quaternion rotPt = new Quaternion(UnityEngine.Random.Range(0f, 5.0f), UnityEngine.Random.Range(0f, 3.0f), 0, 0);
            Quaternion rotPf = new Quaternion(UnityEngine.Random.Range(0f, 5.0f), UnityEngine.Random.Range(0f, 3.0f), 0, 0);
            Quaternion rotGo = new Quaternion(UnityEngine.Random.Range(0f, 5.0f), UnityEngine.Random.Range(.0f, 3.0f), 0, 0);

            ObjectClassPt Pt = new(ObjectType.Primitive, ColliderType.Trigger, corPt, posPt, rotPt, sclPt);
            ObjectClassPf Pf = new(ObjectType.Prefab, ColliderType.Collider, corPf, posPf, rotPf, sclPf);
            ObjectClassGo Go = new(ObjectType.GameObject, ColliderType.Collider, corGo, posGo, rotGo, sclGo);

            primitive.Add(Pt);
            prefab.Add(Pf);
            gameobject.Add(Go);
        }
    }
    private void ObjectSaveToJson()
    {
        foreach (var item in primitive)
        {
            objectSave.Add(item.GetSaveData());
            Debug.Log("SavePT");
        }

        foreach (var item in prefab)
        {
            objectSave.Add(item.GetSaveData());
            Debug.Log("SavePF");
        }

        foreach (var item in gameobject)
        {
            objectSave.Add(item.GetSaveData());
            Debug.Log("SaveGO");
        }

        Debug.Log("Saveeeeee");

        //Salvando as informações da lista ObjectSave
        var saves = new ObjectSave()
        {
            Saves = objectSave.ToArray()
        };

        var json = JsonUtility.ToJson(saves, true);
        Debug.Log(json);

        Debug.Log(SaveFilePath);

        File.WriteAllText(SaveFilePath, json);
    }



    private void LoadObjectSave()
    {
        Debug.Log("Load");
        var jsonString = File.ReadAllText(SaveFilePath);
        Debug.Log(jsonString);

        var saveData = JsonUtility.FromJson<ObjectSave>(jsonString);
        objectSave = new List<ObjectSaveDTO>();
        objectSave.AddRange(saveData.Saves);

        int aux = 0;
        foreach (var item in objectSave)
        {
            if (objectSave[aux].objT == ObjectType.Primitive)
            {
                ObjectClassPt pt = new ObjectClassPt(objectSave[aux].objT, objectSave[aux].cldr, objectSave[aux].cor, objectSave[aux].pos, objectSave[aux].rot, objectSave[aux].scl);
                primitive.Add(pt);
                Debug.Log("LoadPT");
            }

            else if (objectSave[aux].objT == ObjectType.Prefab)
            {
                ObjectClassPf pf = new ObjectClassPf(objectSave[aux].objT, objectSave[aux].cldr, objectSave[aux].cor, objectSave[aux].pos, objectSave[aux].rot, objectSave[aux].scl);
                prefab.Add(pf);
                Debug.Log("LoadPF");
            }

            else if (objectSave[aux].objT == ObjectType.GameObject)
            {
                ObjectClassGo go = new ObjectClassGo(objectSave[aux].objT, objectSave[aux].cldr, objectSave[aux].cor, objectSave[aux].pos, objectSave[aux].rot, objectSave[aux].scl);
                gameobject.Add(go);
                Debug.Log("LoadGO");
            }

            aux++;
        }

    }

}