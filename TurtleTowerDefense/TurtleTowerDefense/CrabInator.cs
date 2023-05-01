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
            comicSans20 = Content.Load<SpriteFont>("comicSans20");
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
                        spawnPoints.Add(new int[] { i, j });
                    }
                }
            }
        }

        public void CrabSpawning(int wave, Grid grid)
        {
            if (crabListFilled == false)
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

                    crabs.Add(new BasicCrab(basicCrabTexture, spawnPoints[indexOfSpawn], grid.GridBoxes[spawnPoints[indexOfSpawn][0], spawnPoints[indexOfSpawn][1]].X + i * 55, grid.GridBoxes[spawnPoints[indexOfSpawn][0], spawnPoints[indexOfSpawn][1]].Y));
                }

                // If the wave is greater than 2, then brute crabs start spawning
                if (wave > 2)
                {
                    for (int i = 0; i < wave - 2; i++)
                    {
                        indexOfSpawn = rng.Next(0, spawnPoints.Count);
                        crabs.Add(new ChungusCrab(chungusCrabTexture, spawnPoints[indexOfSpawn], grid.GridBoxes[spawnPoints[indexOfSpawn][0], spawnPoints[indexOfSpawn][1]].X + i * 55, grid.GridBoxes[spawnPoints[indexOfSpawn][0], spawnPoints[indexOfSpawn][1]].Y));
                    }
                }

                // If wave is greater than 3, start spawning fast crabs
                if (wave > 3)
                {
                    for (int i = 0; i < wave - 2; i++)
                    {
                        indexOfSpawn = rng.Next(0, spawnPoints.Count);
                        crabs.Add(new FastCrab(fastCrabTexture, spawnPoints[indexOfSpawn], grid.GridBoxes[spawnPoints[indexOfSpawn][0], spawnPoints[indexOfSpawn][1]].X + i * 55, grid.GridBoxes[spawnPoints[indexOfSpawn][0], spawnPoints[indexOfSpawn][1]].Y));
                    }
                }
                crabListFilled = true;
            }
        }

        public void Draw(SpriteBatch sb, MouseState mState, GraphicsDevice gD, bool debugMode)
        {
            for (int i = 0; i < crabs.Count; i++)
            {
                crabs[i].Draw(sb);
                // If in debug mode, print crab HP
                if (debugMode)
                {
                    sb.DrawString(comicSans20, $"{crabs[i].Health}", new Vector2(crabs[i].X + crabs[i].Width / 2, crabs[i].Y + crabs[i].Height / 2), Color.White);
                    sb.End();
                    ShapeBatch.Begin(gD);
                    ShapeBatch.BoxOutline(crabs[i].Hitbox, Color.Black);
                    ShapeBatch.End();
                    sb.Begin();
                }
                else if (crabs[i].Hitbox.Contains(new Point(mState.X, mState.Y)))
                {
                    sb.DrawString(comicSans20, $"{crabs[i].Health}", new Vector2(crabs[i].X + crabs[i].Width / 2, crabs[i].Y + crabs[i].Height / 2), Color.White);
                }
            }
        }

        /// <summary>
        /// Will move the crabs according to the level that's currently loaded
        /// </summary>
        /// <param name="crabPathing"></param>
        public void CrabMovement(Grid grid, ref int homeBaseHP, ref int seashells)
        {
            // Remove crab if it's dead
            for (int i = 0; i < crabs.Count; i++)
            {
                if (crabs[i].Health <= 0)
                {
                    if (crabs[i] is BasicCrab)
                    {
                        seashells += 15;
                    }
                    else if (crabs[i] is FastCrab)
                    {
                        seashells += 5;
                    }
                    else if (crabs[i] is ChungusCrab)
                    {
                        seashells += 35;
                    }
                    crabs.RemoveAt(i);

                }
            }
            if (crabs.Count == 0)
            {
                crabListFilled = false;
                return;
            }
            // For each crab in the crab list, move em!
            foreach (Crab crab in crabs.ToList())
            {
                CrabMotion currentMotion = grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1]].CrabPathing;

                if (crab.XVelo == 0 && currentMotion == CrabMotion.Start)
                {
                    crab.XVelo -= crab.Speed;
                }

                switch (currentMotion)
                {
                    // All scenarios moving left
                    case CrabMotion.ForwardWest:
                    case CrabMotion.TurnRightWest:
                    case CrabMotion.TurnLeftWest:
                    case CrabMotion.Start:

                        // If the crab has passed or is right on the edge of the next spot, change the current location
                        // reset the crab position and start moving them in the direction
                        if (crab.X <= grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] - 1].X)
                        {
                            // Moving up
                            if (grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] - 1].CrabPathing == CrabMotion.TurnRightNorth)
                            {
                                crab.XVelo = 0;
                                crab.YVelo -= crab.Speed;
                                // Just resets its position in case it goes too far to the left
                                crab.X = grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] - 1].X;
                                crab.CurrentLocation = new int[] { crab.CurrentLocation[0], crab.CurrentLocation[1] - 1 };
                                crab.Rotation = 1.5708f;
                            }
                            // Moving down
                            else if (grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] - 1].CrabPathing == CrabMotion.TurnLeftSouth)
                            {
                                crab.XVelo = 0;
                                crab.YVelo += crab.Speed;
                                // Just resets its position in case it goes too far to the left
                                crab.X = grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] - 1].X;
                                crab.CurrentLocation = new int[] { crab.CurrentLocation[0], crab.CurrentLocation[1] - 1 };
                                crab.Rotation = 4.71239f;
                            }
                            // just moving left
                            else if (grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] - 1].CrabPathing == CrabMotion.ForwardWest || grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] - 1].CrabPathing == CrabMotion.Stop)
                            {
                                crab.CurrentLocation = new int[] { crab.CurrentLocation[0], crab.CurrentLocation[1] - 1 };
                            }
                        }
                        break;

                    // All scenarios moving up
                    case CrabMotion.ForwardNorth:
                    case CrabMotion.TurnRightNorth:
                    case CrabMotion.TurnLeftNorth:
                        if (crab.Y <= grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].Y)
                        {
                            // Moving left
                            if (grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.TurnLeftWest)
                            {
                                crab.XVelo -= crab.Speed;
                                crab.YVelo = 0;
                                crab.Y = grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].Y;
                                crab.CurrentLocation = new int[] { crab.CurrentLocation[0] - 1, crab.CurrentLocation[1] };
                                crab.Rotation = 0f;
                            }
                            // Moving right
                            else if (grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.TurnRightEast)
                            {
                                crab.XVelo += crab.Speed;
                                crab.YVelo = 0;
                                crab.Y = grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].Y;
                                crab.CurrentLocation = new int[] { crab.CurrentLocation[0] - 1, crab.CurrentLocation[1] };
                                crab.Rotation = 3.14159f;
                            }
                            // Just moving up
                            else if (grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.ForwardNorth || grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.Stop)
                            {
                                crab.CurrentLocation = new int[] { crab.CurrentLocation[0] - 1, crab.CurrentLocation[1] };
                            }
                        }
                        break;

                    // All scenarios moving down
                    case CrabMotion.ForwardSouth:
                    case CrabMotion.TurnRightSouth:
                    case CrabMotion.TurnLeftSouth:
                        if (crab.Y > grid.GridBoxes[crab.CurrentLocation[0] + 1, crab.CurrentLocation[1]].Y)
                        {
                            // Moving left
                            if (grid.GridBoxes[crab.CurrentLocation[0] + 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.TurnRightWest)
                            {
                                crab.XVelo -= crab.Speed;
                                crab.YVelo = 0;
                                crab.Y = grid.GridBoxes[crab.CurrentLocation[0] + 1, crab.CurrentLocation[1]].Y;
                                crab.CurrentLocation = new int[] { crab.CurrentLocation[0] + 1, crab.CurrentLocation[1] };
                                crab.Rotation = 0f;
                            }
                            // Moving right
                            if (grid.GridBoxes[crab.CurrentLocation[0] + 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.TurnLeftEast)
                            {
                                crab.XVelo += crab.Speed;
                                crab.YVelo = 0;
                                crab.Y = grid.GridBoxes[crab.CurrentLocation[0] + 1, crab.CurrentLocation[1]].Y;
                                crab.CurrentLocation = new int[] { crab.CurrentLocation[0] + 1, crab.CurrentLocation[1] };
                                crab.Rotation = 3.14159f;
                            }
                            // Just moving down
                            else if (grid.GridBoxes[crab.CurrentLocation[0] + 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.ForwardSouth || grid.GridBoxes[crab.CurrentLocation[0] + 1, crab.CurrentLocation[1]].CrabPathing == CrabMotion.Stop)
                            {
                                crab.CurrentLocation = new int[] { crab.CurrentLocation[0] + 1, crab.CurrentLocation[1] };
                            }
                        }
                        break;

                    // All scenarios moving right
                    case CrabMotion.ForwardEast:
                    case CrabMotion.TurnRightEast:
                    case CrabMotion.TurnLeftEast:
                        if (crab.X <= grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] + 1].X)
                        {
                            // Moving up
                            if (grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] + 1].CrabPathing == CrabMotion.ForwardNorth || grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] + 1].CrabPathing == CrabMotion.TurnRightNorth || grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] + 1].CrabPathing == CrabMotion.TurnLeftNorth)
                            {
                                crab.XVelo = 0;
                                crab.YVelo -= crab.Speed;
                                crab.X = grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].X;
                                crab.CurrentLocation = new int[] { crab.CurrentLocation[0] - 1, crab.CurrentLocation[1] };
                                crab.Rotation = 1.5708f;
                            }
                            // Moving down
                            else if (grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] + 1].CrabPathing == CrabMotion.ForwardSouth || grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] + 1].CrabPathing == CrabMotion.TurnRightSouth || grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] + 1].CrabPathing == CrabMotion.TurnLeftSouth)
                            {
                                crab.XVelo = 0;
                                crab.YVelo += crab.Speed;
                                crab.X = grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].X;
                                crab.CurrentLocation = new int[] { crab.CurrentLocation[0] + 1, crab.CurrentLocation[1] };
                                crab.Rotation = 4.71239f;
                            }
                            // Moving left
                            else if (grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] + 1].CrabPathing == CrabMotion.ForwardWest || grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] + 1].CrabPathing == CrabMotion.TurnRightWest || grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] + 1].CrabPathing == CrabMotion.TurnLeftWest)
                            {
                                crab.XVelo -= crab.Speed;
                                crab.YVelo = 0;
                                crab.X = grid.GridBoxes[crab.CurrentLocation[0] - 1, crab.CurrentLocation[1]].X;
                                crab.CurrentLocation = new int[] { crab.CurrentLocation[0], crab.CurrentLocation[1] - 1 };
                            }
                            else if (grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] + 1].CrabPathing == CrabMotion.ForwardEast || grid.GridBoxes[crab.CurrentLocation[0], crab.CurrentLocation[1] + 1].CrabPathing == CrabMotion.Stop)
                            {
                                crab.CurrentLocation = new int[] { crab.CurrentLocation[0], crab.CurrentLocation[1] + 1 };
                            }
                        }
                        break;

                    case CrabMotion.Stop:
                        homeBaseHP -= 10;
                        crabs.Remove(crab);
                        break;

                }
                crab.X += (int)crab.XVelo;
                crab.Y += (int)crab.YVelo;
            }
        }

        /// <summary>
        /// Just deletes all crabs from the list
        /// </summary>
        public void Reset()
        {
            crabs.Clear();
        }

    }
}
