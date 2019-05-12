using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureData
{

    public Enums.StructureType _type { get; set; }

    public StructureData(Enums.StructureType type) {
        _type = type;

        if (type == Enums.StructureType.Spawner) {

        } else if (type == Enums.StructureType.Warfare) {
            
        }
    }



}
