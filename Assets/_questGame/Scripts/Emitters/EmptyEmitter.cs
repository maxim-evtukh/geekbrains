using UnityEngine;

public class EmptyEmitter : MonoBehaviour
{
    #region UnityMethods

    private void Start()
    {
        for (int i = 0; i < 10000; i++)
        {
            var empty = new GameObject();
            empty.AddComponent(typeof(EmptyRotationController));
        }
    }

    #endregion

}

public class EmptyRotationController : MonoBehaviour
{
    #region UnityMethods

    private void Update()
    {
        transform.Rotate(transform.up, 1.0f);
    }

    #endregion
}
