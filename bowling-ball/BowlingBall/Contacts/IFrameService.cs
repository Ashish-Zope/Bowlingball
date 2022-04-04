using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Contacts
{
    public interface IFrameService
    {
        void AddRoll(int pins);
        int GetScore();
    }
}
