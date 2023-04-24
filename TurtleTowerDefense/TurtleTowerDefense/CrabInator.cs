using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeUtils;
using Microsoft.Xna.Framework.Input;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TurtleTowerDefense
{
    internal class CrabInator
    {

        // Fields

        // Game Elements
        protected List<Crab> crabs;
        protected List<Vector2> spawnPoints;
        protected bool crabListFilled;

        // Textures
        private Texture2D basicCrabTexture;
        private Texture2D fastCrabTexture;
        private Texture2D chungusCrabTexture;

        public List<Crab> Crabs { get { return crabs; } }

        /// <summary>
        /// Essentially works as intialization. Sets up all fields
        /// and gives them the proper values to start with.
        /// </summary>
        public CrabInator()
        {
            // Sets up lists for crabs
            crabs = new List<Crab>();
            spawnPoints = new List<Vector2>();
        }

        /// <summary>
        /// Loads up content- really just for textures.
        /// </summary>
        public void LoadContent(ContentManager Content)
        {
            basicCrabTexture = Content.Load<Texture2D>("basic crab sprite");
            fastCrabTexture = Content.Load<Texture2D>("fast crab sprite");
            chungusCrabTexture = Content.Load<Texture2D>("chungus crab sprite");
        }

        /// <summary>
        /// Finds out where the spawn point is, and sets the spawn point variable to those coords
        /// </summary>
        /// <param name="grid"></param>
        public void LocateSpawnPoint(Grid grid)
        {
            // Since the grid is a 2d array, set up two for statements
            for (int i = 0; i < grid.GridBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GridBoxes.GetLength(1); j++)
                {
                    // If the grid is the spawn point, then we've found one of them
                    if (grid.GridBoxes[i, j].CrabPathing == CrabMotion.Start)
                    {
                        spawnPoints.Add(new Vector2(i, j));
                    }
                }
            }
        }

        public void CrabSpawning(int wave, Grid grid)
        {
            LocateSpawnPoint(grid);
            // In the case that there is more than one spawn point, this will randomly generate which for them to spawn at
            Random rng = new Random();
            int indexOfSpawn;

            // Adds 1 + wave crabs to the crab list
            for (int i = 0; i < 1 + wave; i++)
            {
                indexOfSpawn = rng.Next(0, spawnPoints.Count);
                // Really long. What it does:
                // Adds the crab to the list, and also spawns it in it's random spawn location.
                crabs.Add(new BasicCrab(basicCrabTexture, new int[2]{ (int)spawnPoints[indexOfSpawn].X, (int)spawnPoints[indexOfSpawn].Y}, grid.GridBoxes[(int)spawnPoints[indexOfSpawn].X, (int)spawnPoints[indexOfSpawn].Y].X, grid.GridBoxes[(int)spawnPoints[indexOfSpawn].X, (int)spawnPoints[indexOfSpawn].Y].Y));
            }

            // If the wave is greater than 2, then brute crabs start spawning
            if (wave > 2)
            {
                for (int i = 0; i < 1 + wave; i++)
                {
                    indexOfSpawn = rng.Next(0, spawnPoints.Count);
                    crabs.Add(new ChungusCrab(chungusCrabTexture, new int[2] { (int)spawnPoints[indexOfSpawn].X, (int)spawnPoints[indexOfSpawn].Y }, grid.GridBoxes[(int)spawnPoints[indexOfSpawn].X, (int)spawnPoints[indexOfSpawn].Y].X, grid.GridBoxes[(int)spawnPoints[indexOfSpawn].X, (int)spawnPoints[indexOfSpawn].Y].Y));
                }
            }

            // If wave is greater than 3, start spawning fast crabs
            if (wave > 3)
            {
                for (int i = 0; i < 1 + wave; i++)
                {
                    indexOfSpawn = rng.Next(0, spawnPoints.Count);
                    crabs.Add(new FastCrab(fastCrabTexture, new int[2] { (int)spawnPoints[indexOfSpawn].X, (int)spawnPoints[indexOfSpawn].Y }, grid.GridBoxes[(int)spawnPoints[indexOfSpawn].X, (int)spawnPoints[indexOfSpawn].Y].X, grid.GridBoxes[(int)spawnPoints[indexOfSpawn].X, (int)spawnPoints[indexOfSpawn].Y].Y));
                }
            }
        }

        /// <summary>
        /// Will move the crabs according to the level that's currently loaded
        /// </summary>
        /// <param name="crabPathing"></param>
        public void CrabMovement(Grid grid)
        {
            // For each crab in the crab list, move em!
            foreach (Crab crab in crabs)
            {
                CrabMotion currentMotion = grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1]].CrabPathing;

                switch (currentMotion)
                {
                    // All scenarios moving left
                    case CrabMotion.ForwardWest:
                    case CrabMotion.TurnRightWest:
                    case CrabMotion.TurnLeftWest:


                        break;

                    // All scenarios moving up
                    case CrabMotion.ForwardNorth:
                    case CrabMotion.TurnRightNorth:
                    case CrabMotion.TurnLeftNorth:

                        break;

                    // All scenarios moving down
                    case CrabMotion.ForwardSouth:
                    case CrabMotion.TurnRightSouth:
                    case CrabMotion.TurnLeftSouth:

                        break;

                    // All scenarios moving right

                    case CrabMotion.ForwardEast:
                    case CrabMotion.TurnRightEast:
                    case CrabMotion.TurnLeftEast:

                        break;

                }
            }
        }

    }
}
