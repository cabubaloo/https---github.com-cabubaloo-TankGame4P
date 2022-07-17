using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

using Tanks.cast;

namespace Tanks.script {
    class CleanUpExplosionAction : genie.script.Action {
        
        // Member Variables
        // Constructor
        public CleanUpExplosionAction(int priority) : base(priority) {
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {

            AnimatedActor? explode1 = (AnimatedActor?) cast.GetFirstActor("explode1");
            AnimatedActor? explode2 = (AnimatedActor?) cast.GetFirstActor("explode2");
            AnimatedActor? explode3 = (AnimatedActor?) cast.GetFirstActor("explode3");
            AnimatedActor? explode4 = (AnimatedActor?) cast.GetFirstActor("explode4");
            
            if (explode1 != null){
                if (!explode1.IsAnimating())
                {
                    cast.RemoveActor("explode1", explode1);
                }
            }

            if (explode2 != null){
                if (!explode2.IsAnimating())
                {
                    cast.RemoveActor("explode2", explode2);
                }
            }
            if (explode3 != null){
                if (!explode3.IsAnimating())
                {
                    cast.RemoveActor("explode3", explode3);
                }
            }

            if (explode4 != null){
                if (!explode4.IsAnimating())
                {
                    cast.RemoveActor("explode4", explode4);
                }
            }
        }
    }
}
