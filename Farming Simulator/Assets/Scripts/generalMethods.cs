/*
 * 
 * Author: Gabriel Hansley Suarez
 * Date Created: December 22, 2018
 * Source: 
 * 
 * Modified by: Gabriel Hansley Suarez
 * Date Modified: December 22, 2018
 * Last Date Modified: December 22, 2018
 * 
 * Contributors:
 * 
 * Credits: -----------
 * 
 * License: 
 * 
 * Note: Class containing methods that can be used globally
 *     : DO NOT EDIT
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalMethods : MonoBehaviour {

    // Find child with tag in a parent object
    public static GameObject FindGameObjectInChildWithTag(GameObject parent, string tag)
    {
        // Defines the parent object
        Transform t = parent.transform;

        // Iterates through all children of the parent
        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.tag == tag)
            {
                return t.GetChild(i).gameObject;
            }
        }

        return null;
    }

}
