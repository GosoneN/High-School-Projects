using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace AA
{
    public class Camera2d
    {

        public Camera2d(Viewport viewport)
        {
            Origin = new Vector2(viewport.Width / 2, viewport.Height / 2);
            Zoom = 1.0f;
            _viewport = viewport;
        }

        public Vector2 Origin { get; set; }
        public Matrix ViewMatrix { get; set; }
        public float Zoom { get; set; }
        public float Rotation { get; set; }
        private readonly Viewport _viewport;

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;  
 
                // If there's a limit set and the camera is not transformed clamp position to limits
                if(Limits != null && Zoom == 1.0f )
                {
                    _position.X = MathHelper.Clamp(_position.X, Limits.Value.X, Limits.Value.X + Limits.Value.Width - _viewport.Width);
                    _position.Y = MathHelper.Clamp(_position.Y, Limits.Value.Y, Limits.Value.Y + Limits.Value.Height - _viewport.Height);
                }
                else if (Zoom == 2.0f)
                {
                    _position.X = MathHelper.Clamp(_position.X - 64, Limits.Value.X - 248, Limits.Value.X + Limits.Value.Width - _viewport.Width / Zoom);
                    _position.Y = MathHelper.Clamp(_position.Y , Limits.Value.Y, Limits.Value.Y + Limits.Value.Height - _viewport.Height / Zoom);
                }
            }
        }

        private Vector2 _position;

        public void LookAt(Vector2 position)
        {
            Position = position - new Vector2(_viewport.Width / Zoom, _viewport.Height / Zoom);
        }

        public Rectangle? Limits
        {
            get { return _limits; }
            set
            {
                if (value != null)
                {
                    // Assign limit but make sure it's always bigger than the viewport
                    _limits = new Rectangle
                    {
                        X = value.Value.X,
                        Y = value.Value.Y,
                        Width = System.Math.Max(_viewport.Width, value.Value.Width),
                        Height = System.Math.Max(_viewport.Height, value.Value.Height)
                    };

                    // Validate camera position with new limit
                    Position = Position;
                }
                else
                {
                    _limits = null;
                }
            }
        }

        private Rectangle? _limits;

        public Matrix GetViewMatrix(Vector2 parallax)
        {
            // To add parallax, simply multiply it by the position
            return Matrix.CreateTranslation(new Vector3(-Position * parallax, 0.0f)) *
                // The next line has a catch. See note below.
                   Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                   Matrix.CreateRotationZ(Rotation) *
                   Matrix.CreateScale(Zoom, Zoom, 1) *
                   Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }


    }
}
