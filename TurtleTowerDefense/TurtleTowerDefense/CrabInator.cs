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
        protected List<int[]> spawnPoints;
        protected bool crabListFilled;

        // Textures
        private Texture2D basicCrabTexture;
        private Texture2D fastCrabTexture;
        private Texture2D chungusCrabTexture;
        private SpriteFont comicSans20;

        public List<Crab> Crabs { get { return crabs; } }

        /// <summary>
        /// Essentially works as intialization. Sets up all fields
        /// and gives them the proper values to start with.
        /// </summary>
        public CrabInator()
        {
            // Sets up lists for crabs
            crabs = new List<Crab>();
            spawnPoints = new List<int[]>();
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
                        spawnPoints.Add(new int[] { i, j});
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
                crabs.Add(new BasicCrab(basicCrabTexture, spawnPoints[indexOfSpawn], grid.GridBoxes[spawnPoints[indexOfSpawn][0], spawnPoints[indexOfSpawn][1]].X, grid.GridBoxes[spawnPoints[indexOfSpawn][0], spawnPoints[indexOfSpawn][1]].Y));
            }

            // If the wave is greater than 2, then brute crabs start spawning
            if (wave > 2)
            {
                for (int i = 0; i < 1 + wave; i++)
                {
                    indexOfSpawn = rng.Next(0, spawnPoints.Count);
                    crabs.Add(new ChungusCrab(chungusCrabTexture, spawnPoints[indexOfSpawn], grid.GridBoxes[spawnPoints[indexOfSpawn][0], spawnPoints[indexOfSpawn][1]].X, grid.GridBoxes[spawnPoints[indexOfSpawn][0], spawnPoints[indexOfSpawn][1]].Y));
                }
            }

            // If wave is greater than 3, start spawning fast crabs
            if (wave > 3)
            {
                for (int i = 0; i < 1 + wave; i++)
                {
                    indexOfSpawn = rng.Next(0, spawnPoints.Count);
                    crabs.Add(new FastCrab(fastCrabTexture, spawnPoints[indexOfSpawn], grid.GridBoxes[spawnPoints[indexOfSpawn][0], spawnPoints[indexOfSpawn][1]].X, grid.GridBoxes[spawnPoints[indexOfSpawn][0], spawnPoints[indexOfSpawn][1]].Y));
                }
            }
        }

        public void Draw(SpriteBatch sb, bool debugMode)
        {
            for (int i = 0; i < crabs.Count; i++)
            {
                crabs[i].Draw(sb);
                // If in debug mode, print crab HP
                if (debugMode)
                {
                    sb.DrawString(comicSans20, $"{crabs[i].Health}", new Vector2(crabs[i].X + crabs[i].Width / 2, crabs[i].Y + crabs[i].Height / 2), Color.White);
                }
                if (crabs[i].Hitbox.Intersects(homeBaseRect))
                {
                    homeBaseHP -= 10;
                    crabs.Remove(crabs[i]);
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

                        // If the crab has passed or is right on the edge of the next spot, change the current location
                        // reset the crab position and start moving them in the direction
                        if (crab.X <= grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].X)
                        {
                            // Moving up
                            if (grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.ForwardNorth || grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.TurnRightNorth || grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.TurnLeftNorth)
                            {
                                crab.XVelo = 0;
                                crab.YVelo -= crab.Speed;
                                crab.X = grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].X;
                            }
                            // Moving down
                            if (grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.ForwardSouth || grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.TurnRightSouth || grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.TurnLeftSouth)
                            {
                                crab.XVelo = 0;
                                crab.YVelo += crab.Speed;
                                crab.X = grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].X;
                            }
                            // Moving right
                            if (grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.ForwardEast || grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.TurnRightEast || grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.TurnLeftEast)
                            {
                                crab.XVelo += crab.Speed;
                                crab.YVelo = 0;
                                crab.X = grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].X;
                            }
                        }

                        crab.X += (int)crab.XVelo;

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
