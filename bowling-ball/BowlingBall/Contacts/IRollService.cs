using BowlingBall.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Contacts
{
   public interface IRollService
    {
        void UpdateState();
        void UpdateScore( List<Frame>  frames, int  index);
    }
}
