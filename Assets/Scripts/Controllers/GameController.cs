using UnityEngine;



public sealed class GameController : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Transform _camera;
    private ListExecuteObject _listExecuteObject;
    private CameraController _cameraController;
    private InputController _inputController;


    private void Awake()
    {
        _listExecuteObject = new ListExecuteObject();
        _cameraController = new CameraController(_player.transform,_camera);
        _listExecuteObject.AddExecuteObject(_cameraController);
        _inputController = new InputController(_player);
        _listExecuteObject.AddExecuteObject(_inputController);
    }

    private void Update()
    {
        for (var i = 0; i < _listExecuteObject.Length; i++)
        {
            var interactiveObject = _listExecuteObject[i];

            if (interactiveObject == null)
            {
                continue;
            }
            interactiveObject.Execute();
        }

    }



}
