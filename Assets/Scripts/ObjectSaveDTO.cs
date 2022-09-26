using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//tudo que precisa conter no Objeto
public class ObjectSaveDTO
{
    public ObjectType objT;
    //public TransfRef tRef;
    public ColliderType cldr;
    public Color cor;
    public Vector3 pos;
    public Quaternion rot;
    public Vector3 scl;
    public System.Type[] comp;
}
