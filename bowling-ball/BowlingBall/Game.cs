using BowlingBall.Contacts;
using BowlingBall.Dtos;
using BowlingBall.Enums;
using BowlingBall.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
       private IFrameService frameService;
        public Game()
        {

            frameService = new FrameService();
        }
        public void Roll(int pins)
        {
            // Add your logic here. Add classes as needed.
            frameService.AddRoll(pins);
            
        }

        public int GetScore()
        {
            return frameService.GetScore();
        }       
    }
}
