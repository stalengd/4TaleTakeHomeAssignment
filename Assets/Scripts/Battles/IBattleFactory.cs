namespace FourTale.TestCardGame.Battles
{
    public interface IBattleFactory
    {
        IBattle CreateBattle(IBattleDescription description);
    }
}