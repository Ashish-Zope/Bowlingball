using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            var game = new Game();
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.GetScore());
        }



        [TestMethod]
        public void Gutter_game_score_should_return_value_187()
        {
            var game = new Game();
            game.Roll(10);
            game.Roll(9);
            game.Roll(1);
            game.Roll(5);
            game.Roll(5);
            game.Roll(7);
            game.Roll(2);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(9);
            game.Roll(0);
            game.Roll(8);
            game.Roll(2);
            game.Roll(9);
            game.Roll(1);
            game.Roll(10);
            Assert.AreEqual(187, game.GetScore());
        }

        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
