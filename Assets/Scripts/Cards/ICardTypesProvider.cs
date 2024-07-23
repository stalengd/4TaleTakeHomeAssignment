using System.Collections.Generic;

namespace FourTale.TestCardGame.Cards
{
    public interface ICardTypesProvider
    {
        IEnumerable<ICardType> GetAll();
        IEnumerable<ICardType> GetInitial();
    }
}