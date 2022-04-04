using BowlingBall.Contacts;
using BowlingBall.Dtos;
using BowlingBall.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Services
{
    public class StrikeRoll : IRollService
    {
        private Frame frame;
        public StrikeRoll(Frame frame)
        {
            this.frame = frame;
        }
        public void UpdateScore(List<Frame> frames, int  index)
        {
            var nextframe = frames[index + 1];
            frame.FrameScore = frame.Pins.Sum() + nextframe.Pins.Sum();
            if (nextframe.FrameType == FrameType.Strike)
            {
                nextframe = frames[index + 2];
                frame.FrameScore +=  nextframe.Pins[0];
            }
        }
        public void UpdateState()
        {
            frame.FrameType = FrameType.Strike;
            frame.FrameState = FrameState.Completed;
        }
    }
}
