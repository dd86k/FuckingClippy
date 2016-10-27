using System;
using System.Windows.Forms;

namespace FuckingClippy
{
    //TODO: Move this section to the AnimationSystem class as delegates.

    public partial class MainForm
    {
        void InitializeAnimation()
        {
            Character.AnimationSystem.AnimationTimer = new Timer();
            Character.AnimationSystem.AnimationTimer.Interval =
                Character.AnimationSystem.DefaultInterval;
            Character.AnimationSystem.AnimationTimer.Tick += Animation_OnFrame;
        }
        
        /// <remarks>
        /// Animation_OnFrame is within MainForm to access
        /// picCharacter (PictureBox, private).
        /// </remarks>
        void Animation_OnFrame(object s, EventArgs e)
        {
            if (Character.AnimationSystem.CurrentFrame <
                Character.AnimationSystem.MaxFrame)
            {
                picAssistant.Image = Character.AnimationSystem.GetNextFrame();

                // Every 2 frames.
                if (Character.AnimationSystem.CurrentFrame % 2 != 0)
                    GC.Collect(2, GCCollectionMode.Optimized);
            }
            else
            {
                Character.AnimationSystem.Stop();
                picAssistant.Image = Character.AnimationSystem.Idle;
            }
        }
    }
}
