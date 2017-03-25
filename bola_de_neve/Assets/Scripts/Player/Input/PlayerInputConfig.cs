using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class PlayerInputConfig:ScriptableObject
{

    public abstract bool ShootDown { get; }
    public abstract bool ShootUp { get; }

    public abstract Vector3 Axis { get; }
}