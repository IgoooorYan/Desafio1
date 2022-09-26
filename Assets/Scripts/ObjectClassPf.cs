using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClassPf
{
    public ObjectType objT;
    public TransfRef tRef;
    public ColliderType cldr;
    public Color cor;
    public System.Type[] comp;

    public ObjectClassPf(ObjectType objType, ColliderType cld, Color color, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        var gopf = GameObject.Instantiate(Resources.Load<GameObject>("Prefab/Capsule"));
        gopf.name = "Capsule PF";

        gopf.GetComponent<Renderer>().material.color = color;

        gopf.transform.position = position;
        gopf.transform.rotation = rotation;
        gopf.transform.localScale = scale;

        if (cld == ColliderType.Collider)
        {
            if (gopf.TryGetComponent<UnityEngine.Collider>(out UnityEngine.Collider coll) == true)
            {
                gopf.GetComponent<UnityEngine.Collider>().isTrigger = false;
            }

            if (gopf.TryGetComponent<UnityEngine.Collider>(out UnityEngine.Collider coll0) == false)
            {
                gopf.AddComponent<BoxCollider>();
                gopf.GetComponent<BoxCollider>().isTrigger = false;
            }
        }

        else if (cld == ColliderType.Trigger)
        {
            if (gopf.TryGetComponent<UnityEngine.Collider>(out UnityEngine.Collider coll2) == true)
            {
                gopf.GetComponent<UnityEngine.Collider>().isTrigger = true;
            }

            if (gopf.TryGetComponent<UnityEngine.Collider>(out UnityEngine.Collider coll1) == false)
            {
                gopf.AddComponent<BoxCollider>();
                gopf.GetComponent<BoxCollider>().isTrigger = true;
            }
        }

        objT = objType;
        tRef = TransfRef.ToTransfRef(gopf);
        cldr = cld;
        cor = gopf.GetComponent<Renderer>().material.color;
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
