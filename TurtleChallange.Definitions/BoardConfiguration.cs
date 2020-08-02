using System.Runtime.Serialization;

namespace TurtleChallange.Definitions
{
    [DataContract]
    public class BoardConfiguration
    {
        [DataMember]
        public int Size { get; set; }

        [DataMember]
        public int MineCount { get; set; }

        [DataMember]
        public CoordinatePosition StartPosition { get; set; }

        [DataMember]
        public CoordinatePosition EndPosition { get; set; }
    }
}
