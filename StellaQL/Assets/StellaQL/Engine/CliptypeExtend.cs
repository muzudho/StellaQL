//
// (Option) For 2D fighting game.
//
using System.Collections.Generic;

namespace StellaQL
{
    public interface CliptypeExRecordable
    {
        /// <summary>
        /// Tile set file (type) index.
        /// ex. 0:Stand, 1:Jump, 2:Dash, 3:Crouch, 4:Other...
        /// 
        /// When not in use, set it to zero.
        /// </summary>
        int TilesetfileTypeIndex { get; set; }

        /// <summary>
        /// How many frames of animation in 2D animation?
        /// </summary>
        int[] Slices { get; set; }
    }

    public abstract class AbstractCliptypeExRecord : CliptypeExRecordable
    {
        public AbstractCliptypeExRecord(int[] slices, int tilesetfileTypeIndex)
        {
            this.Slices = slices;
            this.TilesetfileTypeIndex = tilesetfileTypeIndex;
        }

        public int TilesetfileTypeIndex { get; set; }
        public int[] Slices { get; set; }
    }

    /// <summary>
    /// I could not think of coined words:-) Tableable.
    /// </summary>
    public interface UserDefinedCliptypeTableable
    {
        /// <summary>
        /// [CliptypeIndex]
        /// </summary>
        Dictionary<int, CliptypeExRecordable> Cliptype_to_exRecord { get; set; }
    }

    public abstract class AbstractCliptypeExTable : UserDefinedCliptypeTableable
    {
        /// <summary>
        /// [CliptypeIndex]
        /// </summary>
        public Dictionary<int, CliptypeExRecordable> Cliptype_to_exRecord { get; set; }
    }
}
