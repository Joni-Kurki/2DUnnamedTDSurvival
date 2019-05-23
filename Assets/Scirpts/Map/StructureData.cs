using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureData
{
    public Enums.StructureType _type { get; set; }
    public float _hp { get; set; }

    public StructureData(Enums.StructureType type, float hp) {
        _type = type;
        _hp = hp;
    }



}
