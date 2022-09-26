using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClassPt
{
    public ObjectType objT;
    public TransfRef tRef;
    public ColliderType cldr;
    public Color cor;
    public System.Type[] comp;

    public ObjectClassPt(ObjectType objType, ColliderType cld, Color color, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        //Criador de objetos com todas os tipos e funções

        var gop = GameObject.CreatePrimitive(PrimitiveType.Cube);
        gop.name = "Cube PT";

        gop.GetComponent<Renderer>().material.color = color;

        gop.transform.position = position;
        gop.transform.rotation = rotation;
        gop.transform.localScale = scale;

        if (cld == ColliderType.Collider)
        {
            if (gop.TryGetComponent<UnityEngine.Collider>(out UnityEngine.Collider coll) == true)
            {
                gop.GetComponent<UnityEngine.Collider>().isTrigger = false;
            }

            if (gop.TryGetComponent<UnityEngine.Collider>(out UnityEngine.Collider coll0) == false)
            {
                gop.AddComponent<BoxCollider>();
                gop.GetComponent<BoxCollider>().isTrigger = false;
            }
        }

        else if (cld == ColliderType.Trigger)
        {
            if (gop.TryGetComponent<UnityEngine.Collider>(out UnityEngine.Collider coll2) == true)
            {
                gop.GetComponent<UnityEngine.Collider>().isTrigger = true;
            }

            if (gop.TryGetComponent<UnityEngine.Collider>(out UnityEngine.Collider coll1) == false)
            {
                gop.AddComponent<BoxCollider>();
                gop.GetComponent<BoxCollider>().isTrigger = true;
            }
        }

        objT = objType;
        tRef = TransfRef.ToTransfRef(gop);
        cldr = cld;
        cor = gop.GetComponent<Renderer>().material.color;
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
