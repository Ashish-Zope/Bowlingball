using BowlingBall.Dtos;
using BowlingBall.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
       private List<Frame> frames;
       private Frame activeFrame;
       private List<int> rolls;
        public Game()
        {
            frames = new List<Frame>();
            rolls = new List<int>();
        }
        public void Roll(int pins)
        {
            // Add your logic here. Add classes as needed.
            AddPinInFrame(pins);
            if(activeFrame.FrameState==FrameState.Completed)
            {
                frames.Add(activeFrame);
                activeFrame = null;
            }
        }

        public int GetScore()
        {
            // Returns the final score of the game.
            for (int i = 0; i < frames.Count(); i++)
            {
                int frameScore = 0;
                var frame = frames[i];
                if (frame.FrameType == FrameType.Spare && !frame.LastFrame)
                {
                    // getnextRoll 
                    var nextframe = frames[i + 1];
                    //get the first pin
                    frameScore = frame.Pins.Sum()+ nextframe.Pins[0];
                }
                else if (frame.FrameType == FrameType.Strike && !frame.LastFrame)
                {
                    var nextframe = frames[i + 1];
                    frameScore = frameScore = frame.Pins.Sum() + nextframe.Pins.Sum();
                    if (nextframe.FrameType==FrameType.Strike)
                    {
                        nextframe = frames[i + 2];
                        frameScore = frameScore + nextframe.Pins[0];
                    }
                }
                else
                {
                    frameScore = frame.Pins.Sum();
                }
                frame.FrameScore = frameScore;
            }
            return frames.Sum(s=>s.FrameScore);
        }

        private void AddPinInFrame(int pins)
        {
            if (activeFrame == null)
            {
                activeFrame = new Frame();
            }
            if(frames.Count==9)
            {
                activeFrame.LastFrame = true;
            }

            if(pins==10)
            {
                activeFrame.Pins.Add(pins);
                activeFrame.FrameType = FrameType.Strike;
                activeFrame.FrameState = FrameState.Completed;
            }
            else if(activeFrame.LastFrame)
            {
                int frameCount = 2;
                activeFrame.Pins.Add(pins);
                //for spare 
                if (activeFrame.Pins.Sum() == 10)
                {
                    activeFrame.FrameType = FrameType.Spare;
                }
                if (activeFrame.LastFrame && activeFrame.FrameType!=FrameType.Normal)
                {
                    frameCount = 3;
                }
                if (activeFrame.Pins.Count>= frameCount)
                {
                    activeFrame.FrameState = FrameState.Completed;
                }             
            }
            else
            {
                int frameCount = 2;
                activeFrame.Pins.Add(pins);               
                if (activeFrame.Pins.Count >= frameCount)
                {
                    activeFrame.FrameState = FrameState.Completed;
                } 
                if (activeFrame.Pins.Sum() == 10)
                {
                    activeFrame.FrameType = FrameType.Spare;
                }
            }

        }
    }
}
