public abstract class GameBaseState
{
    public abstract void Enter(GameManager gm);
    public abstract void Update(GameManager gm);
    public abstract void Leave(GameManager gm);
}