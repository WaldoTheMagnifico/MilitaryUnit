using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryUnit
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                try
                {
                    Mission();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public static void Mission()
        {
            Random rand = new Random();
        
            string MissionOutcome = " ";
            EvilFolk[] EnemyForce = BattleMethod.MakeEvilFolk(rand);
            Personnell[] EvilArmy = BattleMethod.MakeGrunts(rand);
            if (EnemyForce.Length >= EvilArmy.Length)
            {
                BattleMethod.outnumbered = true;
                if (BattleMethod.outnumbered)
                {
                    MissionOutcome = "Retreat!";
                }
        
            }
            else
            {
                MissionOutcome = "Victory!";
            }
        
            Console.WriteLine(MissionOutcome);
            Console.ReadLine();
        }
        
    
    }
    public class Personnell
    {
        public enum Company { Alpha, Bravo, Charlie, Weapons }
        public enum Rank { PVT, PFC, LCPL, CPL, SGT, SSGT, GSGT, MSTSGT, SGTMAJ }

        protected string name;
        protected Rank CurrentRank;
        protected Company AssignedCompany;

        public int HP;

        public virtual void TakeAction()
        {
            Console.WriteLine("Start shooting!");
        }

        public virtual void Run()
        {
            Console.WriteLine("Run quickly!");
        }
    }
    public class Pog : Personnell
    {
       
        public override void TakeAction()
        {
            Console.WriteLine("File paperwork!");
        }
        public override void Run()
        {
            Console.WriteLine("Run Slowly!");
        }
    }
    public class Grunt : Personnell
    {
        public Grunt(Rank CurrentRank, string name, Company AssignedCompany)
        {
            this.CurrentRank = CurrentRank;
            this.name = name;
            this.AssignedCompany = AssignedCompany;
            HP = 250;
        }
        public Grunt()
        { }


    }
    class Weapon
    {
        public enum Caliber { BigBoom, LittleBoom }

        protected int rangeInMeters;
        protected Caliber Cal;
        protected int magCapacity;

        public bool IsLoaded;
        public int RoundCount;
        public bool Shoot;

        public void Fire()
        {
            if (Shoot == true)
            {
                RoundCount++;
            }
            if (RoundCount == magCapacity)
            {
                IsLoaded = false;
            }
        }
        public virtual void Sound()
        {
            Console.WriteLine("BOOM!");
        }
    }
    class SniperRifle : Weapon
    {
        public SniperRifle(bool IsLoaded, int RoundCount)
        {
            this.IsLoaded = IsLoaded;
            this.RoundCount = RoundCount;
            Cal = Caliber.LittleBoom;
            magCapacity = 10;
            rangeInMeters = 1000;
        }
        public override void Sound()
        {
            Console.WriteLine("Pfft!");
        }
    }
    class GranadeLauncher : Weapon
    {
        public GranadeLauncher(bool IsLoaded, int RoundCount)
        {
            this.IsLoaded = IsLoaded;
            this.RoundCount = RoundCount;
            Cal = Caliber.BigBoom;
            magCapacity = 1;
            rangeInMeters = 150;
        }
    }
    class Saw : Weapon
    {
        public Saw(bool IsLoaded, int RoundCount)
        {
            this.IsLoaded = IsLoaded;
            this.RoundCount = RoundCount;
            Cal = Caliber.LittleBoom;
            magCapacity = 75;
            rangeInMeters = 600;
        }
    }
    

    public class EvilFolk : Personnell
    {
    
    }
    public class BattleMethod
    {
        public static bool outnumbered { get; set; }
        public static EvilFolk[] MakeEvilFolk(Random rand)
        {
            EvilFolk[] EnemySquad = new EvilFolk[rand.Next(1, 10)];
            int i = EnemySquad.Length - 1;
            while (i > 0)
            {
                EvilFolk badguy = new EvilFolk();
                EnemySquad[i] = badguy;
                i--;
            }
            foreach (var guy in EnemySquad)
            {
                Console.WriteLine(guy);
            }
            return EnemySquad;
        }
    
        public static Grunt[] MakeGrunts(Random rand)
        {
            Grunt[] Squad = new Grunt[rand.Next(1, 10)];
            int i = Squad.Length -1;
            while (i > 0)
            {
                Grunt grunt = new Grunt();
                
                Squad[i] = grunt;
                i--;
            }
            foreach (var grunt in Squad)
            {
                Console.WriteLine(grunt);
            }
            return Squad;
        }
    }
    public class Vehicle
    {
    
        protected Personnell[] Passengers;
        protected bool IsMoving = false;
        protected bool AtCapacity = false;
    
        public int VehicleCount = 0;
    
        public bool HasArmor { get; set; }
        public int NumberOfSeats { get; set; }
        public bool HasFuel { get; set; }
    
        public virtual bool Move()
        {
            if (HasFuel && AtCapacity && IsMoving == false)
            {
                IsMoving = true;
            }
            else
            {
                IsMoving = false; 
            }
            return IsMoving;
        }
    }
    public class Flyers : Vehicle
    {
        public Flyers(bool HasArmor, bool HasFuel, int NumberOfSeats)
        {
            this.HasArmor = HasArmor;
            this.HasFuel = HasFuel;
            this.NumberOfSeats = NumberOfSeats;
            VehicleCount++;
        }
        public override bool Move()
        {
            if (HasFuel && AtCapacity && IsMoving == false)
            {
                IsMoving = true;
            }
            else
            {
                IsMoving = false;
            }
            return IsMoving;
        }
    }
    public class Rollers : Vehicle
    {
        public Rollers(bool HasArmor, bool HasFuel, int NumberOfSeats)
        {
    
            this.HasArmor = HasArmor;
            this.HasFuel = HasFuel;
            this.NumberOfSeats = NumberOfSeats;
            VehicleCount++;
    
        }
        public override bool Move()
        {
            if (HasFuel && AtCapacity && IsMoving == false)
            {
                IsMoving = true;
                Console.WriteLine("Baby you can drive my car, yes I'm gonna be a star");
            }
            else
            {
                IsMoving = false;
                Console.WriteLine("Were just sittin on the 405 in rush hour");
            }
            return IsMoving;
        }
    }
    public class Swimmers : Vehicle
    {
        public Swimmers(bool HasArmor, bool HasFuel, int NumberOfSeats)
        {
    
            this.HasArmor = HasArmor;
            this.HasFuel = HasFuel;
            this.NumberOfSeats = NumberOfSeats;
            VehicleCount++;
    
        }
        public override bool Move()
        {
            if (HasFuel && AtCapacity && IsMoving == false)
            {
                IsMoving = true;
                Console.WriteLine("Under da sea! Down where it's betta down where it is wetta, take it from me! ");
            }
            else
            {
                IsMoving = false;
                Console.WriteLine("sittin in the dulldrums");
            }
            return IsMoving;
        }
    }
    public class SpaceShip : Vehicle
    {
        public SpaceShip(bool HasArmor, bool HasFuel, int NumberOfSeats)
        {
    
            this.HasArmor = HasArmor;
            this.HasFuel = HasFuel;
            this.NumberOfSeats = NumberOfSeats;
            VehicleCount++;
    
        }
        public override bool Move()
        {
            if (HasFuel && AtCapacity && IsMoving == false)
            {
                IsMoving = true;
                Console.WriteLine("...were in space");
            }
            else
            {
                IsMoving = false;
                Console.WriteLine("we aint going no where, still on the tarmak");
            }
            return IsMoving;
        }
    
    }
}   