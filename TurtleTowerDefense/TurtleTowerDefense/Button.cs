﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TurtleTowerDefense
{
    internal class Button
    {
        private Rectangle box;
        private Vector2 pos;
        private Texture2D texture;
        private Texture2D hover_texture;
        private MouseState prevMouseState;
        private MouseState currMouseState;
        public EventHandler Click;

        public Button(int x, int y, int width, int height, Texture2D texture, Texture2D hover_texture)
        {
            pos = new Vector2(x, y);
            box = new Rectangle(x, y, width, height);
            this.texture = texture;
            this.hover_texture = hover_texture;
        }

        public Texture2D Texture
        {
            set { this.texture = value; }
        }

        public Texture2D Hover_Texture
        {
            set { this.hover_texture = value; }
        }

        //public bool Click()
        //{
        //    if (box.Contains(currMouseState.X, currMouseState.Y))
        //    {
        //        return (currMouseState.LeftButton == ButtonState.Pressed) && (prevMouseState.LeftButton == ButtonState.Released);
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public void Update()
        {
            currMouseState = Mouse.GetState();

            if (box.Contains(currMouseState.X, currMouseState.Y))
            {
                if ((currMouseState.LeftButton == ButtonState.Pressed) && (prevMouseState.LeftButton == ButtonState.Released))
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }

            prevMouseState = currMouseState;
        }

        public void Draw(SpriteBatch sb)
        {
            if (box.Contains(currMouseState.X, currMouseState.Y))
            {
                sb.Draw(hover_texture, box, Color.White);
            }
            else
            {
                sb.Draw(texture, box, Color.White);
            }

        }
    }
}
