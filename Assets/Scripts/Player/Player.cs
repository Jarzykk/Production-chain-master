using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;

    public ImportantSceneObjects ImportantSceneObjects => _importantSceneObjects;
}
