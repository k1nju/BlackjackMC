namespace BlackjackMC.GameEngine
{
    
        public class Player : Participant
            {
                public bool IsStanding { get; private set; } = false;

                public void Stand()
                {
                    IsStanding = true;
                }
            }
        }
    

