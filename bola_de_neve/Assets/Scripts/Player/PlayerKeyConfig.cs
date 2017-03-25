using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/KeyConfig")]
public class PlayerKeyConfig:ScriptableObject
{
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode downKey;
    public KeyCode upKey;

    public KeyCode fireKey;
}
