using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_5._5___Particle_Effects
{
    public class ParticleSystem
    {
        private Random _generator;
        public Vector2 _emitterLocation;
        private List<Particle> _particles;
        private List<Texture2D> _textures;

        public ParticleSystem(List<Texture2D> textures, Vector2 location)
        {
            _emitterLocation = location;
            this._textures = textures;
            this._particles = new List<Particle>();
            _generator = new Random();
        }

        private Particle GenerateNewParticle()
        {
            Texture2D texture = _textures[_generator.Next(_textures.Count)];
            Vector2 position = _emitterLocation;
            Vector2 velocity = new Vector2(
                    1f * (float)(_generator.NextDouble() * 2 - 1),
                    1f * (float)(_generator.NextDouble() * 2 - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(_generator.NextDouble() * 2 - 1);

            //Hexadecimal thing of color, randomly generates every particles
            Color color = new Color(
                    (float)_generator.NextDouble(),
                    (float)_generator.NextDouble(),
                    (float)_generator.NextDouble());
            float size = (float)_generator.NextDouble();
            int time = 20 + _generator.Next(40);

            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, time);
        }

        public void Update()
        {
            int total = 10;

            for (int i = 0; i < total; i++)
            {
                _particles.Add(GenerateNewParticle());
            }

            for (int particle = 0; particle < _particles.Count; particle++)
            {
                _particles[particle].Update();
                if (_particles[particle]._time <= 0)
                {
                    _particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int index = 0; index < _particles.Count; index++)
            {
                _particles[index].Draw(spriteBatch);
            }
        }

    }
}
