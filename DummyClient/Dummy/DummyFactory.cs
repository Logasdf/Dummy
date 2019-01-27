
using Google.Protobuf.State;
using System;
using System.Text;

namespace Dummy
{
    class DummyFactory
    {
        static string[] dummyClntNames;
        static Random random;

        static DummyFactory()
        {
            random = new Random();
            dummyClntNames = new string[16];
            for(int i = 0; i < 16; ++i)
            {
                dummyClntNames[i] = "TempUser#" + (i + 1);
            }
        }

        static float GetDoubleRandomNumber(double min, double max)
        {
            if (min > max)
                return (float)min;

            double res = random.NextDouble() * (max - min) + min;

            return (float)res;
        }

        //static void Main(string[] args)
        //{
        //    DummyFactory factory = new DummyFactory();
        //    WorldState dummy = factory.CreateDummy(35, "Tempsdf");

        //    Console.WriteLine(ToString(dummy));
        //}

        public static string ToString(WorldState worldState)
        {
            StringBuilder sb = new StringBuilder("----------------------\n");
            sb.Append(worldState.Transform.Position.ToString());
            sb.Append("\n");
            sb.Append(worldState.Transform.Rotation.ToString());
            sb.Append("\n");
            sb.Append(worldState.Transform.Scale.ToString());
            sb.Append("\n");
            sb.Append(worldState.HitState.ToString());
            sb.Append("----------------------\n");

            return sb.ToString();
        }

        public WorldState CreateDummy(int roomId, string clntName)
        {
            WorldState dummy = new WorldState
            {
                RoomId = roomId,
                ClntName = clntName,
                Transform = new TransformProto
                {
                    Position = new Vector3Proto
                    {
                        X = GetDoubleRandomNumber(50.0, 200.0),
                        Y = GetDoubleRandomNumber(50.0, 200.0),
                        Z = GetDoubleRandomNumber(50.0, 200.0),
                    },
                    Rotation = new Vector3Proto
                    {
                        X = GetDoubleRandomNumber(50.0, 200.0),
                        Y = GetDoubleRandomNumber(50.0, 200.0),
                        Z = GetDoubleRandomNumber(50.0, 200.0),
                    },      
                    Scale = new Vector3Proto
                    {      
                        X = GetDoubleRandomNumber(50.0, 200.0),
                        Y = GetDoubleRandomNumber(50.0, 200.0),
                        Z = GetDoubleRandomNumber(50.0, 200.0),
                    }
                },
                Fired = (random.Next(0, 2) == 1) ? true : false,
                Health = 100,
                Hit = (random.Next(0, 2) == 1) ? true : false,
                HitState = new HitState
                {
                    From = dummyClntNames[random.Next(0, 16)],
                    To = dummyClntNames[random.Next(0, 16)],
                    Damage = 10,
                },
                KillPoint = random.Next(0, 100),
                DeathPoint = random.Next(0, 100),
                AnimState = random.Next(0, 3),
            };

            return dummy;
        }
    }
}
