using BowlingBall.Contacts;
using BowlingBall.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Dtos
{
    public  class Frame
    {
        public Frame()
        {
            this.Pins = new List<int>();
        }
        public List<int> Pins { get; set; }
        public int FrameScore { get; set; }
        public FrameType FrameType { get; set; }
        public FrameState FrameState { get; set; }
        public bool LastFrame { get; set; }
        public IRollService RollService { get; set; }
    }
}
