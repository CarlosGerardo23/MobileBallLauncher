using UnityEngine;

public abstract class BaseScriptableObject : ScriptableObject
{
    [TextArea(3, 10)]
    [SerializeField] private string _developerDescription = null;
}
