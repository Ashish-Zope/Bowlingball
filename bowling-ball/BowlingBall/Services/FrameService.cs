using BowlingBall.Contacts;
using BowlingBall.Dtos;
using BowlingBall.Enums;
using System.Collections.Generic;
using System.Linq;

namespace BowlingBall.Services
{
   public class FrameService: IFrameService
    {   
        private List<Frame> frames;
        private Frame activeFrame;
        private List<int> rolls;
        public FrameService()
        {
            frames = new List<Frame>();
            rolls = new List<int>();
        }

        public void AddRoll(int pins)
        {
            AddPinInFrame(pins);
            if (activeFrame.FrameState == FrameState.Completed)
            {
                frames.Add(activeFrame);
                activeFrame = null;
            }        
        }
        public int GetScore()
        {

            for (int i = 0; i < frames.Count(); i++)
            {                
                var frame = frames[i];
                var rollService = frame.RollService;
                rollService.UpdateScore(frames, i);
            }
            return frames.Sum(s=>s.FrameScore);
            
        }
        private void AddPinInFrame(int pins)
        {
            if (activeFrame == null)
            {
                activeFrame = new Frame();
            }
            if (frames.Count == 9)
            {
                activeFrame.LastFrame = true;
            }
             activeFrame.Pins.Add(pins);
             var roll = GetRollType();
            if(roll!=null)
            {
                roll.UpdateState();
                activeFrame.RollService = roll;
            }           
        }

        private IRollService GetRollType()
        {
            if (activeFrame.Pins[0] == 10)
            {
                return new StrikeRoll(activeFrame);
            }
            else if (activeFrame.LastFrame)
            {
                return new LastRoll(activeFrame);
            }
            else if (activeFrame.Pins.Sum() == 10)
            {
                return new SpareRoll(activeFrame);
            }
            else if (activeFrame.Pins.Count == 2 && activeFrame.Pins.Sum() < 10)
                return new NormalFrame(activeFrame);
            else return null;
           
        }      
    }
}
