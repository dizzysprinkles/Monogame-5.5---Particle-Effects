using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_5._5___Particle_Effects
{
    public class Particle
    {
        public Texture2D _texture;        
        public Vector2 _position;
        public Vector2 _velocity;
        public float _angle;
        public float _angularVelocity;    
        public Color _color;           
        public float _size;                
        public int _time;

        public Particle(Texture2D texture, Vector2 position, Vector2 velocity,
            float angle, float angularVelocity, Color color, float size, int time)
        {
            _texture = texture;
            _position = position;
            _velocity = velocity;
            _angle = angle;
            _angularVelocity = angularVelocity;
            _color = color;
            _size = size;
            _time = time;
        }

        public void Update()
        {
            _time--;
            _position += _velocity;
            _angle += _angularVelocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, _texture.Width, _texture.Height);
            Vector2 origin = new Vector2(_texture.Width / 2, _texture.Height / 2);

            spriteBatch.Draw(_texture, _position, sourceRectangle, _color, _angle, origin, _size, SpriteEffects.None, 0f);
        }



    }

}
