using System.Collections.Generic;
using UnityEngine;
using FourTale.TestCardGame.AI;
using FourTale.TestCardGame.Battles;
using FourTale.TestCardGame.Characters.Rendering;

namespace FourTale.TestCardGame.Characters
{
    public sealed class CharactersFactory : ICharactersFactory
    {
        private readonly IMainCharacterService _mainCharacterService;
        private readonly ICharacterRenderersField _characterRenderersField;

        public CharactersFactory(IMainCharacterService mainCharacterService, ICharacterRenderersField characterRenderersField)
        {
            _mainCharacterService = mainCharacterService;
            _characterRenderersField = characterRenderersField;
        }

        public IBattleCharacters Create(IBattleDescription battleDescription)
        {
            var playerCharacters = new List<ICharacter>() { CreatePlayerCharacter() };
            var enemyCharacters = new List<ICharacter>();
            for (int i = 0; i < battleDescription.Enemies.Count; i++)
            {
                var enemyDesc = battleDescription.Enemies[i];
                var behaviour = battleDescription.Behaviours[i];
                enemyCharacters.Add(CreateEnemyCharacter(enemyDesc, behaviour, i));
            }
            return new BattleCharacters(playerCharacters, enemyCharacters);
        }

        private ICharacter CreatePlayerCharacter()
        {
            var description = _mainCharacterService.CharacterDescription;
            var (_, renderer, cardTarget) = CreateCharacterRenderer(Fraction.Player, 0, description.Prefab);
            var character = new Character(Fraction.Player, description.Health, renderer);
            cardTarget.Bind(character);
            return character;
        }

        private ICharacter CreateEnemyCharacter(CharacterDescription description, AICharacterBehaviourGameObject behaviourPrefab, int index)
        {
            var (rendererObj, renderer, cardTarget) = CreateCharacterRenderer(Fraction.Enemy, index, description.Prefab);
            var behaviour = Object.Instantiate(behaviourPrefab.gameObject, rendererObj.transform)
                .GetComponent<AICharacterBehaviourGameObject>();
            var character = new AICharacter(Fraction.Enemy, description.Health, renderer, behaviour);
            behaviour.MountCharacter(character);
            cardTarget.Bind(character);
            return character;
        }

        private (GameObject, ICharacterRenderer, CharacterCardTarget) CreateCharacterRenderer(Fraction fraction, int index, GameObject prefab)
        {
            var obj = Object.Instantiate(prefab);
            var renderer = obj.GetComponent<ICharacterRenderer>();
            var cardTarget = obj.AddComponent<CharacterCardTarget>();
            _characterRenderersField.PlaceCharacter(fraction, index, obj);
            return (obj, renderer, cardTarget);
        }
    }
}
