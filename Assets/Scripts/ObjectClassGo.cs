using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClassGo
{
    public ObjectType objT;
    public TransfRef tRef;
    public ColliderType cldr;
    public Color cor;
    public System.Type[] comp;

    public ObjectClassGo(ObjectType objType, ColliderType cld, Color color, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        var go = new GameObject();
        go.name = "GO";

        go.transform.position = position;
        go.transform.rotation = rotation;
        go.transform.localScale = scale;

        if (cld == ColliderType.Collider)
        {
            if (go.TryGetComponent<UnityEngine.Collider>(out UnityEngine.Collider coll) == true)
            {
                go.GetComponent<UnityEngine.Collider>().isTrigger = false;
            }

            if (go.TryGetComponent<UnityEngine.Collider>(out UnityEngine.Collider coll0) == false)
            {
                go.AddComponent<BoxCollider>();
                go.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
        else if (cld == ColliderType.Trigger)
        {
            if (go.TryGetComponent<UnityEngine.Collider>(out UnityEngine.Collider coll2) == true)
            {
                go.GetComponent<UnityEngine.Collider>().isTrigger = true;
            }

            if (go.TryGetComponent<UnityEngine.Collider>(out UnityEngine.Collider coll1) == false)
            {
                go.AddComponent<BoxCollider>();
                go.GetComponent<BoxCollider>().isTrigger = true;
            }
        }

        if (go.TryGetComponent<UnityEngine.Renderer>(out UnityEngine.Renderer red) == false)
        {
            go.AddComponent<SpriteRenderer>();
            go.GetComponent<Renderer>().material.color = color;
        }

        objT = objType;
        tRef = TransfRef.ToTransfRef(go);
        cldr = cld;
        cor = color;
    }

    public ObjectSaveDTO GetSaveData()

    {
        var save = new ObjectSaveDTO()
        {
            objT = this.objT,
            cldr = this.cldr,
            cor = this.cor,
            pos = this.tRef.position,
            rot = this.tRef.rotation,
            scl = this.tRef.scale,
            comp = this.comp,
        };
        return save;
    }
}
