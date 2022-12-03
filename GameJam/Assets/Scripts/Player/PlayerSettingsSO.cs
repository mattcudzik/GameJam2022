using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/Player Settings SO")]
public class PlayerSettingsSO : ScriptableObject
{
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    public KeyCode interact;

    public Player player; 
    public enum Player
    {
        Player1,
        Player2
    }
}