namespace FourTale.TestCardGame.Battles
{
    public interface IBattlesProvider
    {
        IBattleDescription GetOrDefault(int index);
    }
}