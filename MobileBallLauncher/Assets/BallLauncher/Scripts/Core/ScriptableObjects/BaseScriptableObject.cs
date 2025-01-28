using UnityEngine;
namespace BallLauncher.Core.ScriptableObjects
{
    public abstract class BaseScriptableObject : ScriptableObject
    {
        [TextArea(3, 10)]
        [SerializeField] private string _developerDescription = null;
    }
}