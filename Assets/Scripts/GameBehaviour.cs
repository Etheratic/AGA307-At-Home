using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    protected static GameManager _GM { get { return GameManager.INSTANCE; } }
    protected static TargetManager _TM { get { return TargetManager.INSTANCE; } }
}
