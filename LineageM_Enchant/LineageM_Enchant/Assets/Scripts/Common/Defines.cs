using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneState
{
    None = -1,
    Title,
    Lobby,
    Battle,
}

public static class Version
{
    public const string value = "1.0.0";
}