using System;

namespace Proj_Mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        public interface Imediator
        {
            public void interaction();
        }

        public class Mediator : Imediator
        {
            public Piece piece;
            public Part part;
            public Thing thing;

            public Mediator()
            {

            }
        }
    }
}
