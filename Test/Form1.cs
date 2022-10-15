using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Graphics g;
        private List<Rectangle> rectangles = new List<Rectangle>();
        const int N = 3;
        private List<RectangleToDelete> queueForDeletion = new List<RectangleToDelete>();
        Timer timer = new Timer();
        private void turnOff_On_Button_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            timer.Interval = (1000);
            timer.Tick += TimerTick;
        }
        private void TimerTick(object sender, EventArgs e)
        {
            CreateAndDrawRandomRectangle();
            SearchIntersectionRectangles();
            List<RectangleToDelete> deleteFromQueue = new List<RectangleToDelete>();
            foreach (RectangleToDelete rect in queueForDeletion)
            {
                if (rect.Iteration == N)
                {
                    DeleteRectangle(rect.CurrentRectanglesToDeleteList);
                    deleteFromQueue.Add(rect);
                }
                rect.Iteration++;
            }
            foreach(RectangleToDelete rect in deleteFromQueue)
            {
                queueForDeletion.Remove(rect);
            }
        }
        private List<Region> FindIntersectRegions(Rectangle rectToDel)
        {
            Region rectToDelRegion = new Region(rectToDel);
            List<Region> intersectRegions = new List<Region>();
            foreach (Rectangle rect in rectangles)
            {
                if (rectToDel.Contains(rect)) { continue; }
                if (rectToDel != rect)
                {
                    Region rectRegion = new Region(rect);
                    if (rectToDel.IntersectsWith(rect))
                    {
                        rectRegion.Intersect(rectToDelRegion);
                        intersectRegions.Add(rectRegion);
                    }
                }
            }
            return intersectRegions;
        }
        private void DeleteRectangle(List<Rectangle> rectanglesToDelete)
        {
            foreach (Rectangle rectToDel in rectanglesToDelete)
            {
                if (rectToDel != rectanglesToDelete.Last())
                {
                    Region intesectRegion = UnionIntersectRegion(FindIntersectRegions(rectToDel));//все пересечения прямоугльника который удолится с другими прямоугольниками
                    Region rectToDelRegion = new Region(rectToDel);
                    rectToDelRegion.Xor(intesectRegion);
                    g.FillRegion(new SolidBrush(this.BackColor), rectToDelRegion);//закрашивание областей прямоугольника не попадающих на друге прямоугольники
                }
            }
            foreach (Rectangle rectToDel in rectanglesToDelete)
            {
                if (rectToDel != rectanglesToDelete.Last())
                {
                    rectangles.Remove(rectToDel);
                }
            }
        }
        private Region UnionIntersectRegion(List<Region> regions)
        {
            Region allToClear = new Region();
            if (regions.Count() != 0)
            {
                allToClear = regions[0];
            }
            foreach (Region reg in regions)
            {
                if (reg != regions.First())
                {
                    allToClear.Union(reg);
                }
            }
            return allToClear;
        }
        private void CreateAndDrawRandomRectangle()
        {
            Random rnd = new Random();
            Color color = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            Rectangle rect = new Rectangle(rnd.Next(Width), rnd.Next(Height), rnd.Next(20, 400), rnd.Next(20, 400));
            rectangles.Add(rect);
            g.FillRectangle(new SolidBrush(color), rect);
        }
        private void SearchIntersectionRectangles()//находит все прямоугольники которые пересекаются с новым, создает список прямоугольников на удаление
        {
            List<Rectangle> result = new List<Rectangle>();
            for (int i = 0; i < rectangles.Count() - 1; i++)
            {
                if (rectangles[i].IntersectsWith(rectangles.Last()))
                {
                    result.Add(rectangles[i]);
                }
            }
            if (result.Count() != 0)
            {
                result.Add(rectangles.Last());
                queueForDeletion.Add(new RectangleToDelete(result));
            }
        }
    }
}
