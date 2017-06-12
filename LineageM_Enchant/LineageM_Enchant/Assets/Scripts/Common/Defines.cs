using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneState
{
    None = -1,
    Main,
    ItemList,
    ItemInchent,
    ItemBuy,
}

public static class Version
{
    public const string value = "1.0.0";
}