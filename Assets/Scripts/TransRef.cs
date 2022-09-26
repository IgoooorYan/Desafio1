using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransfRef
{
    public Vector3 position = new Vector3();
    public Vector3 scale = new Vector3();
    public Quaternion rotation; // = new Quaternion();


    //Transformando o transform em position, rotation e scale para que o Json possa ler 
    static public TransfRef ToTransfRef(GameObject go)
    {
        var trfm = go.GetComponent<Transform>();
        var tRef = new TransfRef() { position = trfm.position, rotation = trfm.rotation, scale = trfm.localScale };

        return tRef;
    }
}
