﻿using System;
using System.Diagnostics;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace HuntTheWumpus
{
    enum GameState { MainMenu, InGame }

    class Program
    {
        public static GameState current = GameState.InGame;

        static GameControl game = new GameControl();

        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(740, 640), "Hunt The Wumpus", Styles.Close);
            window.Closed += OnClosed;

            Image image = new Image("icon.png");
            window.SetIcon(32, 32, image.Pixels);

            Stopwatch clock = new Stopwatch();
            clock.Start();
            double dt = 0;

            while (window.IsOpen())
            {
                dt = (double)clock.Elapsed.Milliseconds / 100.0;
                clock.Restart();

                window.DispatchEvents();

                if (current == GameState.InGame) // Update code
                    game.Update(dt);

                window.Clear();

                if (current == GameState.InGame) // Draw code
                    game.Draw(ref window);

                window.Display();
            }
        }

        static void OnClosed(object sender, EventArgs e)
        {
            RenderWindow window = sender as RenderWindow;
            window.Close();
        }
    }
}
