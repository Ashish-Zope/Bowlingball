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
   public class SpareRoll: IRollService
    {
      private  Frame frame;
      private readonly  int frameCount = 2;
        public  SpareRoll(Frame frame)
        {
            this.frame = frame;
        }
        public void UpdateScore(List<Frame> frames, int index)
        {
            var nextframe = frames[index + 1];
            //        //get the first pin
           frame.FrameScore = frame.Pins.Sum() + nextframe.Pins[0];
        }
        public void UpdateState()
        {
           // frame.Pins.Add(pins);
            frame.FrameType = FrameType.Spare;
            if (frame.Pins.Count>=frameCount)
            frame.FrameState = FrameState.Completed;
        }
    }
}
