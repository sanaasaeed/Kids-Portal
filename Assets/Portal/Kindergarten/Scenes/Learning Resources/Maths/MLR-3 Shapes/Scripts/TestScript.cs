using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public NoOfShapesLists noOfShapesList = new NoOfShapesLists();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class NoOfShapesLists {
    public List<int> noOfShapes;
}
 
/*
[System.Serializable]
public class NoOfShapesList {
    public List<NoOfShapes> shapeList;
}
*/
