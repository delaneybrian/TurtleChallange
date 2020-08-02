using System.Runtime.Serialization;

namespace TurtleChallange.Definitions
{
    [DataContract]
    public class CoordinatePosition
    {
        [DataMember]
        public int XCoordinate { get; set; }

        [DataMember]
        public int YCoordinate { get; set; }
    }
}
