using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Fruit : Item {

    public float spoil;

    void FixedUpdate()
    {
        spoil++;
        if(spoil >= 100)
        {
            this.gameObject.SetActive(false);
            print (this.gameObject.name +"spoiled");
        }
    }
}
