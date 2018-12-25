/*
 * 
 * Author: Gabriel Hansley Suarez
 * Date Created: December 20, 2018
 * Source: 
 * 
 * Modified by: Gabriel Hansley Suarez
 * Date Modified: December 20, 2018
 * Last Date Modified: December 20, 2018
 * 
 * Contributors:
 * 
 * Credits: -----------
 * 
 * License: 
 * 
 * Note: Defines what kind of tile
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDefinition : MonoBehaviour {

    public string type;
    public bool isBuildable, isFarmable;

    void Start()
    {
        type = "grass";
        isBuildable = true;
        isFarmable = false;
    }

}
