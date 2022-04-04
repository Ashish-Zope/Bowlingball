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
   public class NormalFrame: IRollService
    {
        private Frame frame;
        public NormalFrame(Frame frame)
        {
            this.frame = frame;
        }
        public void UpdateScore(List<Frame> frames, int index)
        {
            frame.FrameScore= frame.Pins.Sum();
        }
        public void UpdateState()
        {
            frame.FrameType = FrameType.Normal;
            if(frame.Pins.Count()==2)
            frame.FrameState = FrameState.Completed;
        }
    }
}
