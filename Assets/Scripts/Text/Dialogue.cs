using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] //Hace visible las oraciones en el editor.
public class Dialogue
{
    public string name;

    [TextArea(3,10)] //Fija el tamaño para escribir las oraciones en el editor.
    public string[] sentenceList;
}
