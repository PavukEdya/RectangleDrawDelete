using System.Collections.Generic;
using System.Drawing;

namespace Test
{
    public class RectangleToDelete
    {
        private readonly List<Rectangle> currentRectanglesToDeleteList;
        public List<Rectangle> CurrentRectanglesToDeleteList { get { return currentRectanglesToDeleteList; } }
        private int iteration;
        public int Iteration { get; set; }
        public RectangleToDelete(List<Rectangle> curRectToDelList,int iteration = 0) 
        {
            currentRectanglesToDeleteList = curRectToDelList;
            this.iteration = iteration;
        }        
    }
}
