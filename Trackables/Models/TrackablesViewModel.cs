using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Models
{
    public class TrackablesViewModel
    {
        public IEnumerable<Trackable> Trackables { get; set; }
    }
}