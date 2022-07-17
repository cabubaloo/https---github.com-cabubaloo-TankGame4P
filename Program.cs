﻿using Raylib_cs;

using genie;
using genie.cast;
using genie.script;
using genie.test;
using genie.services;
using genie.services.raylib;

using Tanks.cast;
using Tanks.script;



namespace Tanks {
    public static class Program {
        public static void Test() {
            // MouseMap mouseMap = new MouseMap();
            // mouseMap.getRaylibMouse(-1);

            // CastScriptTest castScriptTest = new CastScriptTest();
            // castScriptTest.testCast();
            // castScriptTest.testScript();

            ServicesTest servicesTest = new ServicesTest();
            servicesTest.TestScreenService();

            // Director director = new Director();
            // director.DirectScene();
        }

        public static void Main(string[] args) {   
            // Some constants W_SIZE and, Screen_title and FPS are for our screen
            (int, int) W_SIZE = (1000, 800);
            //(int, int) START_POSITION = (500, 700);
            //int TANK_WIDTH = 40;
            //int TANK_LENGTH = 50;
            string SCREEN_TITLE = "Tanks";
            int FPS = 60;
            //All the services initiated

            RaylibKeyboardService keyboardService = new RaylibKeyboardService();
            RaylibPhysicsService physicsService = new RaylibPhysicsService();
            RaylibScreenService screenService = new RaylibScreenService(W_SIZE, SCREEN_TITLE, FPS);
            RaylibAudioService audioService = new RaylibAudioService();
            RaylibMouseService mouseService = new RaylibMouseService();

            // Creates Director

            Director director = new Director();

           
            //Lets construct the Tank and the Building 
            //Heres one of the players
            Tank tank1  = new Tank("Tanks/assets/Tanks/greentank.png", 50, 50, 900, 700, 0, 0, 0, 0);

            Tank tank3  = new Tank("Tanks/assets/Tanks/bluetank.png", 50, 50, 900, 100, 0, 0, 180, 0);

            Tank tank4  = new Tank("Tanks/assets/Tanks/redtank.png", 50, 50, 100, 700, 0, 0, 0, 0);

            // Here's our second Player

            Tank tank2 = new Tank("Tanks/assets/Tanks/yellowtank.png", 50, 50, 100, 100, 0, 0, 180, 0);

            //Here's the start game button
            StartGameButton startGameButton = new StartGameButton("Tanks/assets/Startbutton/110-1108877_start-button-start-button-png.png", 305, 113, W_SIZE.Item1/2, W_SIZE.Item2/2);

            // Lets create the cast so we can add to it
            Cast cast = new Cast();

           
            // Lets add it to Our cast
            cast.AddActor("Tank1", tank1);
            
            cast.AddActor("Tank2", tank2);

            cast.AddActor("Tank3", tank3);
            
            cast.AddActor("Tank4", tank4);

            cast.AddActor("start_button", startGameButton);

            // Create Script
            Script script = new Script();

            // Add Actions to my script
            script.AddAction("input", new HandleQuitAction(1,screenService));

            // Add actions that must be added to the script when the game starts: (NOTE CLASSES THAT ARE
            // COMMENTED OUT ARE TEMPLATES FROM THE EXAMPLE CODE NOT NEEDED OR NOT YET NEEDED)
            Dictionary<string, List<genie.script.Action>> startGameActions = new Dictionary<string, List<genie.script.Action>>();
            startGameActions["input"] = new List<genie.script.Action>();
            startGameActions["update"] = new List<genie.script.Action>();
            startGameActions["output"] = new List<genie.script.Action>();

            startGameActions["input"].Add(new HandleTankMovementAction(2, keyboardService));
            startGameActions["input"].Add(new ShootingAction(2, keyboardService, audioService));
            // startGameActions["update"].Add(new SpawnAsteroidsAction(1, W_SIZE, (float)1.5));

            script.AddAction("input", new HandleStartGameAction(2, mouseService, physicsService, startGameActions, audioService));
            script.AddAction("input", new SpawnWalls(1, "Tanks/assets/Levels/level2.json"));
            script.AddAction("input", new HandleStartGameAction(2, mouseService, physicsService, startGameActions, audioService));
            script.AddAction("input", new SpawnWalls(1, "Tanks/assets/Levels/level1.json"));

            // // Add all update actions 
            script.AddAction("update", new MoveActorsAction(1, physicsService));
            script.AddAction("update", new HandleOffscreenAction(1, W_SIZE));
            script.AddAction("update", new HandleTankWallCollision(1, physicsService));
             
            script.AddAction("update", new HandleTankBulletCollisionAction(1, physicsService, audioService));
            script.AddAction("update", new CleanUpExplosionAction(1));
            script.AddAction("update", new HandleBulletWallCollision(1, physicsService, audioService));
           
            // // Add all output actions
            script.AddAction("output", new DrawActorsAction(1, screenService));
            script.AddAction("output", new UpdateScreenAction(2, screenService));

            // // Yo, director, do your thing!
            director.DirectScene(cast, script);
        }
    }
}