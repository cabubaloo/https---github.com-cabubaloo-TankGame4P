using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

using Tanks.cast;

namespace Tanks.script {
    class HandleTankBulletCollisionAction : genie.script.Action {

        
        // Member Variables
        RaylibPhysicsService physicsService;
        // RaylibAudioService audioService;
        private genie.cast.Actor? tank1;
        private genie.cast.Actor? tank2;
        private genie.cast.Actor? tank3;
        private genie.cast.Actor? tank4;

        private RaylibAudioService audioService;


        // Constructor
        public HandleTankBulletCollisionAction(int priority, RaylibPhysicsService physicsService, RaylibAudioService audioService ) : base(priority) {
            this.tank1 = null;
            this.tank2 = null;
            this.tank3 = null;
            this.tank4 = null;
            this.physicsService = physicsService;
            this.audioService = audioService;
            
             
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {
            // Grab the tank from the cast
            this.tank1 = cast.GetFirstActor("Tank1");
            this.tank2 = cast.GetFirstActor("Tank2");
            this.tank3 = cast.GetFirstActor("Tank3");
            this.tank4 = cast.GetFirstActor("Tank4");


             // List for Tank explosion animation pictures

            List<string> pictures = new List<string>( );


            // pictures we're adding for the explosion animation

            for (int i = 0; i <2; i++)
            {
            
            pictures.Add($"Tanks/assets/Animations/test{i}.png");
           
            }

            // Have a for loop that iterates each item in that list 

            // Only worry about collision if the ship actually exists
            if (this.tank2 != null) {
                foreach (Actor bullet in cast.GetActors("bullets")) {
                    if ((this.physicsService.CheckCollision(this.tank2, bullet) & physicsService.IsAbove(tank2, bullet)) |(this.physicsService.CheckCollision(this.tank2, bullet) & physicsService.IsLeftOf(tank2, bullet)) |(this.physicsService.CheckCollision(this.tank2, bullet) & physicsService.IsRightOf(tank2, bullet)) |(this.physicsService.CheckCollision(this.tank2, bullet) & physicsService.IsBelow(tank2, bullet)) ) {
                        
                        cast.RemoveActor("Tank2", tank2);
                        cast.RemoveActor("bullets", bullet);

                        AnimatedActor animatedExplosionT2 = new AnimatedActor(pictures, tank2.GetWidth(), tank2.GetHeight(), 5, 60, true, tank2.GetX(), tank2.GetY(), 0, 0, 0, 0, false );
                        
                        animatedExplosionT2.SetAnimating(true);
                        cast.AddActor("explode2", animatedExplosionT2);
                        
                        this.audioService.PlaySound("Tanks/assets/Sound/Victory.mp3", 1);
                        
                        tank2.SetX(100);
                        tank2.SetY(100);
                        tank2.SetRotation(180);
                        cast.AddActor("Tank2", tank2);
                        
                    }
                }
            }

            if (this.tank1 != null) {
                foreach (Actor bullet in cast.GetActors("bullets")) {
                    if ((this.physicsService.CheckCollision(this.tank1, bullet) & physicsService.IsAbove(tank1, bullet)) |(this.physicsService.CheckCollision(this.tank1, bullet) & physicsService.IsLeftOf(tank1, bullet)) |(this.physicsService.CheckCollision(this.tank1, bullet) & physicsService.IsRightOf(tank1, bullet)) |(this.physicsService.CheckCollision(this.tank1, bullet) & physicsService.IsBelow(tank1, bullet))) {

                        cast.RemoveActor("Tank1", tank1);
                        cast.RemoveActor("bullets", bullet);

                        AnimatedActor animatedExplosionT1 = new AnimatedActor(pictures, tank1.GetWidth(), tank1.GetHeight(), 5, 60, true, tank1.GetX(), tank1.GetY(), 0, 0, 0, 0, false );
                        
                        animatedExplosionT1.SetAnimating(true);
                        
                        cast.AddActor("explode1",animatedExplosionT1);

                        this.audioService.PlaySound("Tanks/assets/Sound/Victory.mp3", 1);

                        tank1.SetX(900);
                        tank1.SetY(700);
                        tank1.SetRotation(0);
                        cast.AddActor("Tank1", tank1);
                    }
                }
            }

            if (this.tank3 != null) {
                foreach (Actor bullet in cast.GetActors("bullets")) {
                    if ((this.physicsService.CheckCollision(this.tank3, bullet) & physicsService.IsAbove(tank3, bullet)) |(this.physicsService.CheckCollision(this.tank3, bullet) & physicsService.IsLeftOf(tank3, bullet)) |(this.physicsService.CheckCollision(this.tank3, bullet) & physicsService.IsRightOf(tank3, bullet)) |(this.physicsService.CheckCollision(this.tank3, bullet) & physicsService.IsBelow(tank3, bullet))) {
                        
                        cast.RemoveActor("Tank3", tank3);
                        cast.RemoveActor("bullets", bullet);

                        AnimatedActor animatedExplosionT3 = new AnimatedActor(pictures, tank3.GetWidth(), tank3.GetHeight(), 5, 60, true, tank3.GetX(), tank3.GetY(), 0, 0, 0, 0, false );
                        
                        animatedExplosionT3.SetAnimating(true);
                        
                        cast.AddActor("explode3",animatedExplosionT3);

                        this.audioService.PlaySound("Tanks/assets/Sound/Victory.mp3", 1);

                        tank3.SetX(900);
                        tank3.SetY(100);
                        tank3.SetRotation(180);
                        cast.AddActor("Tank3", tank3);
                    }
                }
            }
            
            if (this.tank4 != null) {
                foreach (Actor bullet in cast.GetActors("bullets")) {
                    if ((this.physicsService.CheckCollision(this.tank4, bullet) & physicsService.IsAbove(tank4, bullet)) |(this.physicsService.CheckCollision(this.tank4, bullet) & physicsService.IsLeftOf(tank4, bullet)) |(this.physicsService.CheckCollision(this.tank4, bullet) & physicsService.IsRightOf(tank4, bullet)) |(this.physicsService.CheckCollision(this.tank4, bullet) & physicsService.IsBelow(tank4, bullet))) {

                        cast.RemoveActor("Tank4", tank4);
                        cast.RemoveActor("bullets", bullet);

                        AnimatedActor animatedExplosionT4 = new AnimatedActor(pictures, tank4.GetWidth(), tank4.GetHeight(), 5, 60, true, tank4.GetX(), tank4.GetY(), 0, 0, 0, 0, false );
                        
                        animatedExplosionT4.SetAnimating(true);
                        
                        cast.AddActor("explode4",animatedExplosionT4);

                        this.audioService.PlaySound("Tanks/assets/Sound/Victory.mp3", 1);

                        tank4.SetX(100);
                        tank4.SetY(700);
                        tank4.SetRotation(0);
                        cast.AddActor("Tank4", tank4);
                    }
                }
            }
        }
    }
}