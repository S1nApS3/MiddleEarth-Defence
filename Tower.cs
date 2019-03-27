using System;

namespace TowerDefense
{
  class Tower
  {
      private const int _range = 1;      
      private const int _damage = 1;
      private const double _accuracy = 0.75;
    
      private static readonly Random _random = new Random();
    
      private readonly MapLocation _location;
    
      public Tower(MapLocation location)
      {
        _location = location;
        
      }
    
      public bool IsSuccessfulShot()
      {
        return _random.NextDouble() < _accuracy;
      }
    
      public void FireOnInvaders(Invader[] invaders)
      {
          const int range = 1;
          foreach(Invader invader in invaders)
          {
            if(invader.IsActive && _location.InRangeOf(invader.Location, _range))
            {
              if(IsSuccessfulShot())
              {
                invader.DecreaseHealth(_damage);
                Console.WriteLine("Damage is done to invader");
                
                if(invader.IsNeutralized)
                {Console.WriteLine("Invader is DEAD.");}
               
              }
              else {Console.WriteLine ("Missed.");}
              
              break;
              
            }
          }
      }
    
  }
}