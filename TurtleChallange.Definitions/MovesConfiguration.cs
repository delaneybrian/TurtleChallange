using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TurtleChallange.Definitions
{
    [DataContract]
    public class MovesConfiguration
    {
        [DataMember]
        public ICollection<string> Moves { get; set; } = new List<string>();
    }
}
