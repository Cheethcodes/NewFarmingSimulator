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
 * Note: Game Manager 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {

    // Help menu box
    public Text helptextContainer;

    // Object to be used to populate the world space
    public Transform objGrass;

    // Initial transform position of the first object (-200, 200)
    private float initialX = -200.0f;
    private float initialY = 200.0f;

    // Offset of the specified object to be instantiated in the sequence (x -= 0.9, y -= 0.5)
    private float offsetX = 1f;
    private float offsetY = 0.5f;
    private Transform grass;
    private SpriteRenderer render;
    // New position of the instantiated tile
    private float newX;
    private float newY;

	void Start ()
    {
        // Fill in details and instructions for help menu context
        //helptextContainer = GameObject.Find("helpmenucontext").GetComponent<Text>();
        helptextContainer.text = "HOW TO PLAY THE GAME";

        // Populate world space with tile sprites in an X x Y axis 
        for (int x = 0; x < 200; x++)
        {
            initialX += (offsetX + 1);

            for (int y = 1; y < 201; y++)
            {
                newY = initialY - (offsetY + (y-1));
                // If current tile is even
                if (y % 2 == 0)
                {
                    newX = initialX + 1f;
                    grass = Instantiate(objGrass, new Vector2(newX, newY), objGrass.rotation);
                    render = grass.GetComponent<SpriteRenderer>();
                    render.sortingOrder = y - 1;
                }

                // If current tile is odd
                else
                {
                    grass = Instantiate(objGrass, new Vector2(initialX, newY), objGrass.rotation);
                    render = grass.GetComponent<SpriteRenderer>();
                    render.sortingOrder = y - 1;
                }
            }
        }
    }
}
