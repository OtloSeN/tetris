using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Tetris
{
    /// <summary>
    /// Class that randomly selects a new shape for the player to control
    /// and returns it to the game class
    /// </summary>
    [Serializable]
    [DataContract]
    [KnownType(typeof(Shape))]
    public class Block : ICloneable
    {
        #region Variables/Properties

        [DataMember]
        private Shape shape;
        [DataMember]
        public int x { get; set; }
        [DataMember]
        public int y { get; set; }
        [DataMember]
        public Int32 blockColor { get; set; }
        [DataMember]
        public bool[][] currBlock;
       static Random rand = new Random();

        #endregion Variables/Properties

        /// <summary>
        /// Default constructor for the Block class
        /// </summary>
        public Block()
        {
            shape = new Shape();
            getNextBlock();
        }

        #region Methods

        /// <summary>
        /// Creates a new block for the player to control
        /// </summary>
        public void getNextBlock()
        {
            if(rand==null)
            {
                rand = new Random();
            }
            int randomBlock = rand.Next(7);
            int startPos = rand.Next(6);
            x = startPos;
            y = 0;
          
            if(shape?.BlockConfig==null)
            {
                shape = new Shape();
            }
                bool [,] temp = shape.BlockConfig[randomBlock];
            currBlock = new bool[4][];

            for (int i = 0; i < 4; i++)
            {
                currBlock[i] = new bool[4];

                for(int j=0;j< 4;j++)
                {
                    currBlock[i][j] = temp[i, j];
                }
            }
            
         
            blockColor = shape.ColorSet[randomBlock];
        }

        public Coordinate toBoardCoord(Coordinate coord)
        {
            coord.x += x;
            coord.y += y;
            return coord;
        }

        /// <summary>
        /// Clone the current block
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return (Block)MemberwiseClone();
        }

        /// <summary>
        /// rotate a shape clockwise
        /// </summary>
        public void rotateClockwise()
        {
            bool [][] newArray = new bool[4][];

            for(int i=0;i<4; i++)
            {
                newArray[i] = new bool[4];
            }
            
            for (int i = 3; i > -1; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    newArray[j][ 3 - i] = currBlock[i][ j];
                }
            } 
            currBlock = newArray;
        }

        /// <summary>
        /// rotate a shape counter clockwise
        /// </summary>
        public void rotateCounterClockwise()
        {
            rotateClockwise();
            rotateClockwise();
            rotateClockwise();
        }

      

        #endregion
    }
}
