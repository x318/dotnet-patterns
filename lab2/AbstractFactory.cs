using System;

namespace lab2
{
    public abstract class SpaceShipFactoryBase
    {
        public int Health { get; set; }
        public string? Type { get; protected set; }

        public abstract EnergyBase CreateEnergy();
        public abstract EngineBase CreateEngine();
        public abstract GunBase CreateGun();
    }

    #region EnergyBase

    public abstract class EnergyBase
    {
        public int Volume { get; protected set; }
        public abstract int Using(int volume);
    }

    public class SunEnergy : EnergyBase
    {
        public SunEnergy()
        {
            Volume = 100;
        }

        public override int Using(int volume)
        {
            if (volume < 0)
                throw new ArgumentException("Расход топлива не может быть отрицательным.", nameof(volume));

            return Volume;
        }
    }

    public class PlasmEnergy : EnergyBase
    {
        public PlasmEnergy()
        {
            Volume = 100;
        }

        public override int Using(int volume)
        {
            if (volume < 0)
                throw new ArgumentException("Расход топлива не может быть отрицательным.", nameof(volume));

            if (Volume >= volume)
            {
                Volume -= volume;
                return Volume;
            }

            return 0;
        }
    }

    #endregion

    #region GunBase

    public abstract class GunBase
    {
        public int Distance { get; protected set; }
        public abstract int Shoot();
    }

    public class LaserGun : GunBase
    {
        public LaserGun()
        {
            Distance = 100;
        }

        public override int Shoot()
        {
            return 30;
        }
    }

    public class PhotonGun : GunBase
    {
        private Random rnd = new Random();
        private readonly int minDamage = 10;
        private readonly int maxDamage = 80;
        private readonly int missChance = 10;

        public PhotonGun()
        {
            Distance = 300;
        }

        public override int Shoot()
        {
            int miss = rnd.Next(0, 100);

            if (miss < missChance)
                return 0;

            int dmg = rnd.Next(minDamage, maxDamage);

            return dmg;
        }
    }

    #endregion

    #region EngineBase

    public abstract class EngineBase
    {
        public int UsingEnergy { get; protected set; }

        public virtual int Move(EnergyBase energy)
        {
            if (energy == null)
                throw new ArgumentNullException(nameof(energy));

            energy.Using(UsingEnergy);

            return 1;
        }
    }

    public class PhotonEngine : EngineBase
    {
        private Random rnd = new Random();
        private readonly int maxFactor = 10;

        public PhotonEngine()
        {
            UsingEnergy = 3;
        }

        public override int Move(EnergyBase energy)
        {
            if (energy == null)
                throw new ArgumentNullException(nameof(energy));

            int factorEnergy = rnd.Next(0, maxFactor);
            energy.Using(UsingEnergy * factorEnergy);

            int factorSpeed = rnd.Next(0, maxFactor);
            return UsingEnergy * factorSpeed;
        }
    }

    public class PulseEngine : EngineBase
    {
        private readonly int speedFactor = 5;

        public override int Move(EnergyBase energy)
        {
            if (energy == null)
                throw new ArgumentNullException(nameof(energy));

            int baseSpeed = base.Move(energy);

            return baseSpeed * speedFactor;
        }

        public PulseEngine()
        {
        }
    }

    #endregion

    #region Factories

    public class PirateSpaceshipFactory : SpaceShipFactoryBase
    {
        public PirateSpaceshipFactory()
        {
            Health = 200;
            Type = "Pirate ship";
        }

        public override EnergyBase CreateEnergy()
        {
            return new PlasmEnergy();
        }

        public override EngineBase CreateEngine()
        {
            return new PhotonEngine();
        }

        public override GunBase CreateGun()
        {
            return new PhotonGun();
        }
    }

    public class MillitarySpaceshipFactory : SpaceShipFactoryBase
    {
        public MillitarySpaceshipFactory()
        {
            Health = 500;
            Type = "Millitary ship";
        }

        public override EnergyBase CreateEnergy()
        {
            return new PlasmEnergy();
        }

        public override EngineBase CreateEngine()
        {
            return new PhotonEngine();
        }

        public override GunBase CreateGun()
        {
            return new PhotonGun();
        }
    }

    public class SpaceShip
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Health { get; private set; }

        private EnergyBase energy;
        private GunBase gun;
        private EngineBase engine;

        public SpaceShip(string name, SpaceShipFactoryBase factory)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            Name = name;
            Type = factory.Type;
            Health = factory.Health;
            energy = factory.CreateEnergy();
            gun = factory.CreateGun();
            engine = factory.CreateEngine();
        }

        public int Shoot()
        {
            return gun.Shoot();
        }

        public int Move()
        {
            return engine.Move(energy);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public override string ToString()
        {
            return $"{Type} \"{Name}\"";
        }
    }

    #endregion
}