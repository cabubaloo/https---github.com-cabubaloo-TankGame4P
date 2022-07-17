using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

namespace Tanks.script
{

    class HandleTankWallCollision : genie.script.Action
    {
        private RaylibPhysicsService physicsService;

        // private RaylibKeyboardService keyboardService;
        private genie.cast.Actor? tank1;
        private genie.cast.Actor? tank2;
        private genie.cast.Actor? tank3;
        private genie.cast.Actor? tank4;

        // private List<int> keysOfInterest;
        // private int tankMovementVel;

        public HandleTankWallCollision(int priority, RaylibPhysicsService physicsService) : base(priority)
        {

            this.physicsService = physicsService;
            this.tank1 = null;
            this.tank2 = null;
            // this.keyboardService = keyboardService;
            // this.keysOfInterest = new List<int>();
            // this.keysOfInterest.Add(Keys.LEFT);
            // this.keysOfInterest.Add(Keys.RIGHT);
            // this.keysOfInterest.Add(Keys.DOWN);
            // this.keysOfInterest.Add(Keys.UP);

            // this.keysOfInterest.Add(Keys.W);
            // this.keysOfInterest.Add(Keys.A);
            // this.keysOfInterest.Add(Keys.S);
            // this.keysOfInterest.Add(Keys.D);
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback)
        {
        // Get my tank actors so I can check their position

            this.tank1 = cast.GetFirstActor("Tank1");

            this.tank2 = cast.GetFirstActor("Tank2");

            this.tank3 = cast.GetFirstActor("Tank3");

            this.tank4 = cast.GetFirstActor("Tank4");

                // Only worry about collision if the ship actually exists
            if (this.tank1 != null) {
                foreach (Actor newWall in cast.GetActors("walls")) {
                    if (this.physicsService.CheckCollision(this.tank1, newWall)) {

                        if (physicsService.IsAbove(tank1, newWall))
                        {
                            tank1.SetVy(0);
                            tank1.SetY(tank1.GetY() - (tank1.GetWidth()/ 10));

                        }

                        if (physicsService.IsBelow(tank1, newWall))
                        {

                            tank1.SetVy(0);
                            tank1.SetY(tank1.GetY() + (tank1.GetWidth() / 10));
                        }

                        if (physicsService.IsLeftOf(tank1, newWall))
                        {

                            tank1.SetVx(0);
                            tank1.SetX(tank1.GetX() - (tank1.GetWidth()/ 10));

                        }

                        if (physicsService.IsRightOf(tank1, newWall))
                        {

                            tank1.SetVx(0);
                            tank1.SetX(tank1.GetX() + (tank1.GetWidth() / 10));

                        }
                    }
                }
            }



            if (this.tank2 != null) {
                foreach (Actor Wall in cast.GetActors("walls")) {
                    if (this.physicsService.CheckCollision(this.tank2, Wall)) {
    
                        if (physicsService.IsAbove(tank2, Wall))
                        {
                            tank2.SetVy(0);
                            tank2.SetY(tank2.GetY() - (tank2.GetWidth()/ 10));
    
                        }
    
                        if (physicsService.IsBelow(tank2, Wall))
                        {
                        
                            tank2.SetVy(0);
                            tank2.SetY(tank2.GetY() + (tank2.GetWidth() / 10));
                        }
    
                        if (physicsService.IsLeftOf(tank2, Wall))
                        {
                        
                            tank2.SetVx(0);
                            tank2.SetX(tank2.GetX() - (tank2.GetWidth()/ 10));
    
                        }
    
                        if (physicsService.IsRightOf(tank2, Wall))
                        {
                            
                            tank2.SetVx(0);
                            tank2.SetX(tank2.GetX() + (tank2.GetWidth() / 10));
    
                        }
                    }
                }
            }

            if (this.tank3 != null) {
                foreach (Actor newWall in cast.GetActors("walls")) {
                    if (this.physicsService.CheckCollision(this.tank3, newWall)) {

                        if (physicsService.IsAbove(tank3, newWall))
                        {
                            tank3.SetVy(0);
                            tank3.SetY(tank3.GetY() - (tank3.GetWidth()/ 10));

                        }

                        if (physicsService.IsBelow(tank3, newWall))
                        {

                            tank3.SetVy(0);
                            tank3.SetY(tank3.GetY() + (tank3.GetWidth() / 10));
                        }

                        if (physicsService.IsLeftOf(tank3, newWall))
                        {

                            tank3.SetVx(0);
                            tank3.SetX(tank3.GetX() - (tank3.GetWidth()/ 10));

                        }

                        if (physicsService.IsRightOf(tank3, newWall))
                        {

                            tank3.SetVx(0);
                            tank3.SetX(tank3.GetX() + (tank3.GetWidth() / 10));

                        }
                    }
                }
            }
            
            if (this.tank4 != null) {
                foreach (Actor newWall in cast.GetActors("walls")) {
                    if (this.physicsService.CheckCollision(this.tank4, newWall)) {

                        if (physicsService.IsAbove(tank4, newWall))
                        {
                            tank4.SetVy(0);
                            tank4.SetY(tank4.GetY() - (tank4.GetWidth()/ 10));

                        }

                        if (physicsService.IsBelow(tank4, newWall))
                        {

                            tank4.SetVy(0);
                            tank4.SetY(tank4.GetY() + (tank4.GetWidth() / 10));
                        }

                        if (physicsService.IsLeftOf(tank4, newWall))
                        {

                            tank4.SetVx(0);
                            tank4.SetX(tank4.GetX() - (tank4.GetWidth()/ 10));

                        }

                        if (physicsService.IsRightOf(tank4, newWall))
                        {

                            tank4.SetVx(0);
                            tank4.SetX(tank4.GetX() + (tank4.GetWidth() / 10));

                        }
                    }
                }
            }
        }
    }
}
