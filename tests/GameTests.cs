using System.Collections.Generic;
using MasterMind.Core;
using Xunit;

namespace MasterMind.UnitTests
{
    public class GameTests
    {
        [Fact]
        public void Game_NewGameIsNotFinished()
        {
            var game = new Game();

            Assert.False(game.IsFinished);
        }

        [Fact]
        public void Game_StartsOnTurnOne()
        {
            var game = new Game();
            Assert.Equal(1, game.Turn);
        }

        [Fact]
        public void Game_WhenCodeIsGuessed_GameIsFinished()
        {
            var code = new Code(new List<Color> { Color.Black, Color.Blue, Color.Green, Color.Red });
            var game = new Game(code);
            game.Guess(new Guess(Color.Black, Color.Blue, Color.Green, Color.Red));
            Assert.True(game.IsFinished);
        }

        [Fact]
        public void Game_WhenCodeIsNotGuessed_GameIsNotFinished()
        {
            var code = new Code(new List<Color> { Color.Black, Color.Blue, Color.Green, Color.Red });
            var game = new Game(code);
            game.Guess(new Guess(Color.Red, Color.Red, Color.Red, Color.Red));
            Assert.False(game.IsFinished);
        }
    }
}
