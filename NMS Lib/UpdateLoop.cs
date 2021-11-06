using System.Collections.Generic;
using System.Threading.Tasks;
using NMSLib.Interfaces;

namespace NMSLib
{
    class UpdateLoop
    {
        List<INMSMod> nmsMods = new List<INMSMod>();

        public UpdateLoop(List<INMSMod> nmsMods)
        {
            this.nmsMods = nmsMods;
        }

        public void StartUpdateLoop()
        {
            while (true)
            {
                FireUpdate();
            }
        }

        public void StartUpdateLoopAsync()
        {
            Task.Factory.StartNew(() => StartUpdateLoop());
        }

        private void FireUpdate()
        {
            nmsMods.ForEach(mod => mod.Update());
        }
    }
}
