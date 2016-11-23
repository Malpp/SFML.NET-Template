using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Diagnostics;

namespace SFML.Net_Template
{
	class Application
	{

		#region Global vars

		//The window of application
		private RenderWindow window;

		//Used to time the movement of the objects on screen
		Clock clock = new Clock();
		Time gameTime = new Time();

		//FPS vars
		float timeElapsed = 0;
		int fps = 0;

		int WINDOW_HEIGHT;
		int WINDOW_WIDTH;

		#endregion

		/// <summary>
		/// Constructor of the window
		/// </summary>
		/// <param name="windowHeight">Height of the window</param>
		/// <param name="windowWidth">Width of the window</param>
		/// <param name="title">Title of the window</param>
		/// <param name="style">Style of the window</param>
		public Application(uint windowHeight = 300, uint windowWidth = 300, string title = "SFML APP", Styles style = Styles.Close)
		{

			window = new RenderWindow(new VideoMode(windowWidth, windowHeight), title, style);

			//Add the keypressed function to the window
			window.KeyPressed += window_KeyPressed;

			//Add the Closed function to the window
			window.Closed += window_Closed;

			//Inits window height and width global vars
			WINDOW_HEIGHT = (int)windowHeight;
			WINDOW_WIDTH = (int)windowWidth;

		}


		/// <summary>
		/// Main loop of the program
		/// </summary>
		public void Run()
		{

			window.SetVisible(true);

			SetUpGlobalVars();

			clock.Restart();

			while(window.IsOpen)
			{

				//Call the Events
				window.DispatchEvents();

				//Update the game
				Update();

				//Draw the updated app
				Draw();

			}


		}

		/// <summary>
		/// Sets up global vars to the program
		/// </summary>
		void SetUpGlobalVars()
		{



		}

		#region Input functions

		/// <summary>
		/// Called whenever a key is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">The key event</param>
		void window_KeyPressed(object sender, KeyEventArgs e)
		{

			//Debug output of keyPressed
			//Console.WriteLine(e.Code);

			switch(e.Code)
			{

				case Keyboard.Key.Escape:
					window.Close();
					break;

				default:
					break;

			}
		}

		/// <summary>
		/// Called when the window "X" is clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void window_Closed(object sender, EventArgs e)
		{

			window.Close();

		}

		#endregion

		/// <summary>
		/// Update code of the program
		/// </summary>
		private void Update()
		{
			
			gameTime = clock.Restart();

			timeElapsed += gameTime.AsSeconds();

			if (timeElapsed > 1)
			{

				Console.WriteLine("FPS: {0}", fps);

				fps = 0;
				timeElapsed = 0;

			}

			fps++;


		}

		/// <summary>
		/// Draw code of the program
		/// </summary>
		private void Draw()
		{

			window.Clear();

			window.Display();

		}

	}
}
