public class InputController:IExecute
{
    private readonly PlayerBase _player;

    public InputController(PlayerBase player)
    {
        _player = player;
    }

    public void Execute()
    {
        _player.GoPoint();
        _player.Fire();
        _player.GoFinish();
    }
}
