using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    [Serializable]
    [DataContract]
   public class Board : Rectangle
    {
        #region fields and properties

        [DataMember]
        public int[][] grid = new int[numRows][];
        [DataMember]
        public int boardColor;

        #endregion
    }
}
