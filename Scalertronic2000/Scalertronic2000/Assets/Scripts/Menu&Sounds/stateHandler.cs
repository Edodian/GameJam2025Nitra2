using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "stateHandler", menuName = "PauseHandling/StateHandler")]
public class stateHandler : ScriptableObject
{
    public bool isPaused;
    public bool isCompleted;
}
