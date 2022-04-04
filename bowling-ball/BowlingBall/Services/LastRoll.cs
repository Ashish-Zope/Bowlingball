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
    public class LastRoll : IRollService
    {
        private Frame frame;
        public LastRoll(Frame frame)
        {
            this.frame = frame;
        }

        public void UpdateScore(List<Frame> frames, int index)
        {
           frame.FrameScore= frame.Pins.Sum();
        }

        public void UpdateState()
        {
            if(frame.Pins[0]==10)
            {
                frame.FrameType = FrameType.Strike;
            }else
            if (frame.Pins.Sum() == 10)
            {
                frame.FrameType = FrameType.Spare;
            }
            if (frame.FrameType == FrameType.Strike || frame.FrameType == FrameType.Spare)
            {
                if (frame.Pins.Count >= 3)
                    frame.FrameState = FrameState.Completed;
            }
            else
            {
                if(frame.Pins.Count>=2)
                frame.FrameState = FrameState.Completed;
            }
        }
    }
}
