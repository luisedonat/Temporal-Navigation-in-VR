using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public Sprite[] circleSprites; // Add all your circle sprites here in the inspector

    private Dictionary<Color, Sprite> colorSpriteMap;

    void Awake()
    {
        // Initialize the dictionary
        colorSpriteMap = new Dictionary<Color, Sprite>();

        // Assume the sprites are named in a specific way like "circle_red", "circle_blue", etc.
        foreach (var sprite in circleSprites)
        {
            Color color;
            if (TryGetColorFromSpriteName(sprite.name, out color))
            {
                colorSpriteMap[color] = sprite;
            }
            else
            {
                Debug.LogError($"Sprite {sprite.name} does not have a valid color mapping.");
            }
        }
    }

    public Sprite GetSpriteForColor(Color color)
    {
        if (colorSpriteMap.TryGetValue(color, out var sprite))
        {
            return sprite;
        }
        else
        {
            Debug.LogError($"No sprite found for color: {color}");
            return null;
        }
    }

    private bool TryGetColorFromSpriteName(string name, out Color color)
    {
        // Define mappings from sprite names to colors
        switch (name.ToLower())
        {
            case "circle_red":
                color = Color.red;
                return true;
            case "circle_blue":
                color = Color.blue;
                return true;
            case "circle_green":
                color = Color.green;
                return true;
            case "circle_yellow":
                color = Color.yellow;
                return true;
            case "circle_grey":
                color = Color.grey;
                return true;
            case "circle_magenta":
                color = Color.magenta;
                return true;
            case "circle_orange":
                color = new Color(1f, 0.65f, 0f);
                return true;
            case "circle_purple":
                color = new Color(0.5f, 0f, 0.5f);
                return true;
            case "circle_white":
                color = Color.white;
                return true;
            case "circle_black":
                color = Color.black;
                return true;
            case "circle_cyan":
                color = Color.cyan;
                return true;    
            default:
                color = Color.clear;
                return false;
        }
    }
}